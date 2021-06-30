using com.cozyhome.Systems;
using UnityEngine;

namespace com.cozyhome.Actors
{
    public class ActorSystem : EntitySystem<CharacterActor>,
        SystemsHeader.IDiscoverSystem,
        SystemsHeader.IFixedSystem
    {
        [SerializeField] private short ExecutionIndex = 100;
        public void OnDiscover()
        {
            SystemsInjector.RegisterFixedSystem(ExecutionIndex, this);
            InitializeEntities();
        }

        public void OnFixedUpdate()
        {
            // auto sync transforms should be true or else you'll experience actor on actor tunneling
            float fdt = Time.fixedDeltaTime;
            Entities.ForEach((CharacterActor actor) => actor.StartFrame());
            Entities.ForEach((CharacterActor actor) => actor.MoveFrame(fdt));
            Entities.ForEach((CharacterActor actor) => actor.EndFrame());
        }

        public static void Register(CharacterActor actor)
        {
            _instance.RegisterEntity(actor);
        }
    }
}