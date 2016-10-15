using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaBasedQuizEngineTemplate.Messages
{
    public class RetrieveQuestionMessage
    {
        public string SessionId { get; private set; }
        public string QuizId { get; private set; }
        public string QuestionId { get; private set; }
        
        public RetrieveQuestionMessage(string sessionId, string quizId, string questionId)
        {
            SessionId = sessionId;
            QuizId = quizId;
            QuestionId = questionId;
        }
    }
}
