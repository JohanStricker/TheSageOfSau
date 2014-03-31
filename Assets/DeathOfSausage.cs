using UnityEngine;
using System.Collections;

public class DeathOfSausage : MonoBehaviour
{

	public Transform particles;

	void OnTriggerEnter(Collider c)
	{
		if (c.transform.tag == "Boulder") {
			if (c.transform.position.y > transform.position.y && c.rigidbody.velocity.magnitude > 1) {
				// kill sausage
				print("OMG THEY KILLED SAUSAGE");
				Transform p = (Transform)Instantiate(particles, transform.position, Quaternion.identity);
				if (transform.name == "Player") {
					StoryCameraTriggers.instance.gameObject.SetActive(true);
					StoryCameraTriggers.TriggerDeath(p);

				} else {
					narratorVoiceScript.Say("KillCreep");

				}
				Destroy(gameObject);

			}

		}

	}

}
