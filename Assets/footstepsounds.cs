using UnityEngine;
using System.Collections;

public class footstepsounds : MonoBehaviour
{

	public AudioSource footstepSource;
	CharacterController cc;
	CharacterMotor cm;

	void Start()
	{
		cc = transform.parent.GetComponent<CharacterController>();
		cm = transform.parent.GetComponent<CharacterMotor>();
	}

	// Update is called once per frame
	void Update()
	{
		if (cc.isGrounded) {
			footstepSource.volume = Mathf.Clamp01(cc.velocity.magnitude / 6);
		} else {
			footstepSource.volume = 0;
		}
	}
}
