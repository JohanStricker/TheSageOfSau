using UnityEngine;
using System.Collections;

public class footstepsoundsMauris : MonoBehaviour
{

	public AudioSource footstepSource;
	Animator anim;
	public float delayOfSound = 4;

	// Use this for initialization
	void Start()
	{
		anim = transform.parent.GetComponent<Animator>();
		delayOfSound += Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		if (delayOfSound < Time.time) {
			footstepSource.volume = anim.GetFloat("Speed");

		}
	}
}
