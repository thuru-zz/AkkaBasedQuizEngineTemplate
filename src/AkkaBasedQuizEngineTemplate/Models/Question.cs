using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaBasedQuizEngineTemplate.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string QuizId { get; set; }
        public string  QuestionContent { get; set; }
        public string Answer { get; set; }
    }
}
