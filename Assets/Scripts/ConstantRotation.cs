using UnityEngine;

namespace Breakout
{
	public class ConstantRotation : MonoBehaviour
	{
		[SerializeField]
		private float speed;

		private void Update()
		{
			transform.Rotate(Vector3.forward, speed * Time.deltaTime);
		}
	}
}
