using UnityEngine;
using Vuforia;

namespace Breakout
{
	[RequireComponent(typeof(TrackableBehaviour))]
	public abstract class BaseTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
	{
		private TrackableBehaviour trackableBehaviour;

		public bool IsTracking { get; private set; }

		protected virtual void Awake()
		{
			trackableBehaviour = GetComponent<TrackableBehaviour>();
		}

		protected virtual void OnEnable()
		{
			trackableBehaviour.RegisterTrackableEventHandler(this);
		}

		protected virtual void OnDisable()
		{
			trackableBehaviour.UnregisterTrackableEventHandler(this);
		}

		public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
				BeginTracking();
			else
				EndTracking();
		}

		private void BeginTracking()
		{
			if (IsTracking)
				return;

			OnBeginTracking();

			IsTracking = true;
		}

		private void EndTracking()
		{
			if (!IsTracking)
				return;

			OnEndTracking();

			IsTracking = false;
		}

		protected abstract void OnBeginTracking();

		protected abstract void OnEndTracking();
	}
}
