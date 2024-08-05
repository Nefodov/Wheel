using UnityEngine;

namespace Map
{
    public class TeleporterData : MapData<Teleporter>
	{
		public Vector3 destination;

        public override Teleporter Deserialize(Teleporter prefab)
        {
            prefab.destination = destination;
            return base.Deserialize(prefab);
        }

        public override void Serialize(Teleporter target)
        {
			destination = target.transform.position;
            base.Serialize(target);
        }
    }
}