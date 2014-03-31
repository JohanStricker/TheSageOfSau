using UnityEngine;
using System.Collections;

public class activateRandomCreeps : MonoBehaviour {

	public bool active = false;

	public float spawnDelay = 10;
	float spawnTimer = 0;

	ButtonPresser bp;
	void Start()
	{
		bp = GetComponent<ButtonPresser>();
	}

	// Update is called once per frame
	void Update () {
		if (active) {
			if (spawnTimer < Time.time) {
				spawnTimer = Time.time + spawnDelay;
				// spawn a creep here!
				bp.SpawnCreepTheProperWay();


			}


		}

	}
}
