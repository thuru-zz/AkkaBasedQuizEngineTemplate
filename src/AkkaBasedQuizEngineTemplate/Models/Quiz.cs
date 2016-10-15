using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaBasedQuizEngineTemplate.Models
{
    public class Quiz
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
