using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaBasedQuizEngineTemplate.Messages
{
    public class RetrieveQuestionMessage
    {
        public RetrieveQuestionMessage(string quizId, string questionId)
        {
            QuizId = quizId;
            QuestionId = questionId;
        }

        public string QuizId { get; private set; }
        public string QuestionId { get; private set; }
    }
}
