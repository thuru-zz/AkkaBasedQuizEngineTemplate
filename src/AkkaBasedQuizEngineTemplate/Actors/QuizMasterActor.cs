using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaBasedQuizEngineTemplate.Actors
{
    public class QuizMasterActor : ReceiveActor
    {
        private readonly IActorRef _surveyTemplateActor;
        private readonly IActorRef _surveySessionCoordinatorActor;

        public QuizMasterActor()
        {
            _surveyTemplateActor = Context.ActorOf<QuizTemplateActor>("QuizTemplateActor");
            _surveySessionCoordinatorActor = Context.ActorOf<QuizSessionCoordinatorActor>("QuizSessionCoordinatorActor");
        }
    }
}
