using UnityEngine;

namespace Breakout
{
	public class SpawnObjectTrackable : BaseTrackableEventHandler
	{
		[SerializeField]
		private GameObject prefab;

		private GameObject instance;

		protected override void OnBeginTracking()
		{
			instance = Instantiate(prefab, this.transform);
		}

		protected override void OnEndTracking()
		{
			Destroy(instance.gameObject);
		}
	}
}
