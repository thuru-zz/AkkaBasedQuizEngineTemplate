using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AkkaBasedQuizEngineTemplate.Models;
using Akka.Actor;
using AkkaBasedQuizEngineTemplate.Messages;
using AkkaBasedQuizEngineTemplate.Actors;
using AkkaBasedQuizEngineTemplate.DTO;

namespace AkkaBasedQuizEngineTemplate.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private ActorSystem _quizActorSystem;

        public QuizController(ActorSystem actorSystem)
        {
            _quizActorSystem = actorSystem;
        }

        [HttpGet, Route("session/{sessionId}/question/{questionId}")]
        public async Task<IActionResult> GetQuestion(string sessionId, string questionId)
        {
            var quizCoordinator = _quizActorSystem.ActorSelection("/user/QuizMasterActor/QuizSessionCoordinatorActor/");
            var quizSession = await quizCoordinator.Ask<IActorRef>(sessionId);
            
            // assuming some part of the session has the quiz Id
            var retrieveQuestionMessage = new RetrieveQuestionMessage(sessionId, sessionId.Split('-')[0], questionId);
            var question = await quizSession.Ask<Question>(retrieveQuestionMessage);

            return Ok(question);
        }

        [HttpPut, Route("session/{sessionId}")]
        public async Task<IActionResult> UpdateAnswer(string sessionId, [FromBody]AnswerDTO answer)
        {
            if (!string.IsNullOrWhiteSpace(answer.Answer))
            {
                var quizCoordinator = _quizActorSystem.ActorSelection("/user/QuizMasterActor/QuizSessionCoordinatorActor/");
                var quizSession = await quizCoordinator.Ask<IActorRef>(sessionId);

                var updateAnswerMessage = new UpdateAnswerMessage(sessionId, answer.QuestionId, answer.Answer);
                quizSession.Tell(updateAnswerMessage);

                return Ok();
            }
            else
            {
                return BadRequest("Answer cannot be null or empty");
            }
        }
    }
}
