using UnityEngine;

namespace Breakout
{
	public class Launch : MonoBehaviour
	{
		[SerializeField]
		private Vector2 velocity;

		private void Start()
		{
			GetComponent<Rigidbody2D>().velocity = velocity;
		}
	}
}
