using com.cozyhome.Archetype;
using UnityEngine;

namespace com.cozyhome.Actors
{
    [RequireComponent(typeof(BoxCollider))]
    public class BoxActor : ActorHeader.Actor
    {
        [System.NonSerialized] private ArchetypeHeader.BoxArchetype BoxArchetype;
        /* UnityEngine */
        void Start()
        {
            SetPosition(transform.position);
            SetOrientation(transform.rotation);
            SetVelocity(Vector3.zero);

            BoxArchetype = new ArchetypeHeader.BoxArchetype(
                GetComponent<BoxCollider>()
            );
        }

        public override ArchetypeHeader.Archetype GetArchetype() => BoxArchetype;

        public override bool DetermineGroundStability(Vector3 _vel, RaycastHit _hit, LayerMask _gfilter)
            => base.DeterminePlaneStability(_hit.normal, _hit.collider);
    }
}