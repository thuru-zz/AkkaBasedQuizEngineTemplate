using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaBasedQuizEngineTemplate.Actors
{
    public class QuizSessionCoordinatorActor : ReceiveActor
    {
        private Dictionary<string, IActorRef> _quizSessions;

        public QuizSessionCoordinatorActor()
        {
            _quizSessions = new Dictionary<string, IActorRef>();

            Receive<string>(sessionId =>
            {
                if (!_quizSessions.Keys.Contains(sessionId))
                {
                    var quizSessionActor = Context.ActorOf(QuizSessionActor.GetQuizSessionActorProps(sessionId), sessionId);
                    _quizSessions[sessionId] = quizSessionActor;
                }

                Sender.Tell(_quizSessions[sessionId]);
            });
        }
    }
}
