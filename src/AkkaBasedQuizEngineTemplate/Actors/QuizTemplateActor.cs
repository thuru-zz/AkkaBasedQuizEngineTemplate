using Akka.Actor;
using AkkaBasedQuizEngineTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaBasedQuizEngineTemplate.Actors
{
    public class QuizTemplateActor : ReceiveActor
    {
        private readonly Dictionary<string, Quiz> _quizTemplates;

        public QuizTemplateActor()
        {
            _quizTemplates = new Dictionary<string, Quiz>();

            Receive<string>(quizId =>
            {
                if(!_quizTemplates.Keys.Contains(quizId))
                {
                    // TODO :: load the survey template from the persistence store.
                    var quiz = new Quiz { Id = quizId, Name = "Quiz 1" };
                    quiz.Questions = new List<Question>
                    {
                        new Question { Id = "a1", QuizId = quizId, QuestionContent = "Question 1" },
                        new Question { Id = "a2", QuizId = quizId, QuestionContent = "Question 2" }
                    };
                    
                    _quizTemplates[quizId] = quiz;
                }

                var quizTemplateReference = _quizTemplates[quizId];
                var newQuiz = new Quiz
                {
                    Id = quizTemplateReference.Id,
                    Name = quizTemplateReference.Name,
                    Questions = new List<Question>(quizTemplateReference.Questions)
                };

                Sender.Tell(newQuiz);
            });
        }
    }
}
