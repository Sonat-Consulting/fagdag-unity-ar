using UnityEngine;

namespace Breakout
{
	public class DestroyOnContact : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D collision)
		{
			Destroy(collision.gameObject);
		}
	}
}
