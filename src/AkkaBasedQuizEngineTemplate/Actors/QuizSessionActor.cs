using Akka.Actor;
using AkkaBasedQuizEngineTemplate.Messages;
using AkkaBasedQuizEngineTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaBasedQuizEngineTemplate.Actors
{
    public class QuizSessionActor : ReceiveActor
    {
        private Quiz _quiz;
        private readonly string _sessionId;

        public QuizSessionActor(string sessionId)
        {
            _sessionId = sessionId;

            Receive<RetrieveQuestionMessage>(message =>
            {
                if(_quiz == null)
                {
                    var templateActor = Context.ActorSelection("/user/QuizMasterActor/QuizTemplateActor");
                    var quiz = templateActor.Ask<Quiz>(message.QuizId).GetAwaiter().GetResult();
                    _quiz = quiz;
                }

                if(message.SessionId == _sessionId)
                {
                    Sender.Tell(_quiz.Questions.Single(q => q.Id == message.QuestionId));
                }
                
            });

            Receive<UpdateAnswerMessage>(message =>
            {
                if(_quiz != null && message.SessionId == _sessionId)
                {
                    var question = _quiz.Questions.Single(q => q.Id == message.QuestionId);
                    question.Answer = message.Answer;
                }
            });
        }

        public static Props GetQuizSessionActorProps(string sessionId)
        {
            return Props.Create(() => new QuizSessionActor(sessionId));
        }
    }
}
