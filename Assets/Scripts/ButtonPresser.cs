using UnityEngine;
using System.Collections;

public class ButtonPresser : MonoBehaviour
{

	public enum buttonTypes
	{
		Desert,
		Forest,
		Swamp,
		Hillside


	}
	public buttonTypes buttonType;
	public Transform whatToSpawn;
	public Transform whereToSpawn;
	bool pressed = false;
	public float timeBetweenEffect = 0.5f;
	float timer = 0;

	private Animator anim;

	// Use this for initialization
	void Start()
	{
		audio.loop = false;
		anim = transform.parent.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider hit)
	{

		if (hit.transform.gameObject.name == "Player" && !pressed) {

			if (buttonType != buttonTypes.Swamp && timer < Time.time) {
				timer = Time.time + timeBetweenEffect;
				Debug.Log("pressed");
				SpawnStuff();

			}

			pressed = true;
			Invoke("PressedFalse", 0.5f);
			// make sound here
			audio.Play();
			anim.SetTrigger("Press");
			narratorVoiceScript.Say("Button");

		}

	}

	void PressedFalse()
	{
		pressed = false;
	}

	void SpawnStuff()
	{
		Vector3 spawnpos;// = whereToSpawn.position;
		if (buttonType == buttonTypes.Forest) {
			spawnpos = Camera.main.transform.position +
				new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z) * -2.0f;

		} else {
			spawnpos = whereToSpawn.position + Vector3.up * 50;
		}

		if (buttonType == buttonTypes.Hillside) {
			spawnAvalange();
		} else if (buttonType == buttonTypes.Forest) {
			Invoke("CreateShit", 2);
		} else {
			Instantiate(whatToSpawn, spawnpos, Quaternion.identity);
		}


	}

	public void SpawnCreepTheProperWay()
	{
		Vector3 spawnpos;// = whereToSpawn.position;
		spawnpos = Camera.main.transform.position +
			new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z) * -2.0f;

		Invoke("CreateShit", 2);
		
	}

	void CreateShit()
	{
		Vector3 spawnpos = Camera.main.transform.position +
				new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z) * -2.6f;
		Instantiate(whatToSpawn, spawnpos, Quaternion.identity);

		transform.GetComponent<activateRandomCreeps>().active = true;
	
	}


	void spawnAvalange()
	{
		Vector3 sp;
		sp = whereToSpawn.position;
		Vector3 spf = whereToSpawn.forward;
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 3; j++) {
				Transform r = (Transform)Instantiate(whatToSpawn, sp + spf * i * 6f + Vector3.up * j * 6f, Quaternion.identity) as Transform;
				r.localScale = new Vector3(Random.Range(0.75f, 1.05f), Random.Range(0.75f, 1.05f), Random.Range(0.75f, 1.05f));

			}
		}
		GameObject.Find("AvalangeMachine").transform.GetChild(0).gameObject.SetActive(true);

		Invoke("SetAvalangeCollider", 7);
	}

	void SetAvalangeCollider()
	{
		GameObject.Find("AvalangeMachine").transform.GetChild(0).gameObject.SetActive(false);

	}
}
