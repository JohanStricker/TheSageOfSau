using UnityEngine;
using System.Collections;

// place this script on one of the rocks
public class FallStones : MonoBehaviour
{

	public Transform[] theOtherRocks = null;

	void Start()
	{
		if (theOtherRocks != null)
			if (theOtherRocks.Length > 0)
				foreach (var tor in theOtherRocks) {
					tor.gameObject.AddComponent<FallStones>();

				}
	}

	void OnTriggerEnter(Collider hit)
	{
		if (transform.name == "stone02") {
			if (hit.tag == "Sausage" || hit.tag == "Player") {
				rigidbody.constraints = RigidbodyConstraints.None;
				foreach (var tor in theOtherRocks) {
					tor.rigidbody.constraints = RigidbodyConstraints.None;

				}
			}
		}
	}
}
