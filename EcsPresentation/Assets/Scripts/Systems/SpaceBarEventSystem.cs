using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBarEventSystem : MonoBehaviour {
	private static SpaceBarEventSystem _instance;

		private void Awake()
		{
			if (_instance == null)
				_instance = this;
			else
				Destroy(this.gameObject);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				var spaceEntity = new GameObject();
				spaceEntity.AddComponent<SpawnPlayerEventComponent>();
			}
		}
}