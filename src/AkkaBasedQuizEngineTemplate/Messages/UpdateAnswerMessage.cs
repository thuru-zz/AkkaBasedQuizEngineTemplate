using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaBasedQuizEngineTemplate.Messages
{
    public class UpdateAnswerMessage
    {
        public string QuestionId { get; private set; }
        public string Answer { get; private set; }

        public UpdateAnswerMessage(string questionId, string answer)
        {
            QuestionId = questionId;
            Answer = answer;
        }
    }
}
