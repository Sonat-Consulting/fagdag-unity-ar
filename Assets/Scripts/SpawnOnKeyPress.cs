using UnityEngine;

namespace Breakout
{
	public class SpawnOnKeyPress : MonoBehaviour
	{
		[SerializeField]
		private KeyCode key = KeyCode.Space;

		[SerializeField]
		private GameObject prefab;

		private void Update()
		{
			if (Input.GetKeyDown(key))
			{
				GameObject instance = Instantiate(prefab);
				instance.transform.position = transform.position;
			}
		}
	}
}
