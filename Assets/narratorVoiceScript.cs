using UnityEngine;
using System.Collections;

public class narratorVoiceScript : MonoBehaviour
{

	public static narratorVoiceScript instance;


	public AudioClip[] moving;
	float lastMovingTime = -1000;

	public AudioClip[] still;
	float lastStillTime = 0;

	public AudioClip[] nearRedButton;
	public AudioClip[] creeps;
	public AudioClip[] killCreeps;
	public AudioClip[] boulders;
	public AudioClip buttonPress;
	public AudioClip gameover;
	public AudioClip endgame;

	public float delay = 5;
	float delayTimer = 0;

	Transform GetNearestNarratorArea()
	{
		
		Transform nearest = null;
		float minimumDist = 10000000;
		foreach (var g in GameObject.FindGameObjectsWithTag("NarratorArea")) {
			if ((transform.position - g.transform.position).magnitude < minimumDist) {
				nearest = g.transform;
				minimumDist = (transform.position - g.transform.position).magnitude;
			}

		}
		print("Nearest narrator area is " + nearest.name);
				
		return nearest;

	}
	public static void Say(string what)
	{
		print(" Someone told me to say " + what);
		if (what == "Button") {
			//instance.sayButton = true;
		} else if (what == "GameOver") {
			instance.sayGameOver = true;
		} else if (what == "KillCreep") {
			instance.sayKillCreep = true;
		}
	}

	bool sayButton = false;
	bool sayGameOver = false;
	bool sayKillCreep = false;


	void Start()
	{
		instance = this;
	}

	// Update is called once per frame
	void Update()
	{


		// movement stuff

		if ((Input.anyKey || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)) {
			lastMovingTime = Time.time;

		}
			// if we haven't moved in the last 2 seconds
		else {
			lastStillTime = Time.time;

		}


		// time to say something
		if (delayTimer < Time.time) {
			delayTimer = Time.time + delay;

			if (sayGameOver) {
				delayTimer += 1000;
				audio.PlayOneShot(gameover);
				sayGameOver = false;

			} else if (sayKillCreep) {
				audio.PlayOneShot(killCreeps[GetRandomKillCreeps()]);
				delayTimer += killCreeps[lastKillCreeps].length;
				sayKillCreep = false;

			} else if (sayButton) {
				delayTimer += buttonPress.length;
				audio.PlayOneShot(buttonPress);
				sayButton = false;

			} else {

				// if there is a nice narratorarea do that
				Transform near = GetNearestNarratorArea();
				print(near.position + " " + transform.position + " " + (near.position - transform.position).magnitude);
				if ((near.position - transform.position).magnitude < near.localScale.x/2) {

					if (near.name == "EndGame") {
						audio.PlayOneShot(endgame);
						delayTimer += 10000;
					} else if (near.name == "Creep") {
						audio.PlayOneShot(creeps[GetRandomCreeps()]);
						delayTimer += creeps[lastCreeps].length;

					} else if (near.name == "Boulders") {
						audio.PlayOneShot(boulders[GetRandomBoulders()]);
						delayTimer += boulders[lastBoulders].length;

					} else if (near.name == "RedButton") {
						audio.PlayOneShot(nearRedButton[GetRandomRedButton()]);
						delayTimer += nearRedButton[lastRedButton].length;

					}


					// otherwise deal with movement
				} else if (lastStillTime > lastMovingTime && (Time.time - lastMovingTime > 2)) {

					audio.PlayOneShot(still[GetRandomStill()]);
					delayTimer += still[lastStillLine].length;
					return;

				} else {

					audio.PlayOneShot(moving[GetRandomMoving()]);
					delayTimer += moving[lastMovingLine].length;
					return;

				}
			}

		}

	}

	int lastMovingLine = 0;
	int GetRandomMoving()
	{
		if (moving.Length > 1) {
			int r = Random.Range(0, moving.Length);
			while (r == lastMovingLine) {
				r = Random.Range(0, moving.Length);
			}
			lastMovingLine = r;
			return r;

		} else {
			return 0;
		}

	}


	int lastStillLine = 0;
	int GetRandomStill()
	{
		if (still.Length > 1) {
			int r = Random.Range(0, still.Length);
			while (r == lastStillLine) {
				r = Random.Range(0, still.Length);
			}
			lastStillLine = r;
			return r;
		} else {
			return 0;
		}

	}

	int lastRedButton = 0;
	int GetRandomRedButton()
	{
		if (nearRedButton.Length > 1) {
			int r = Random.Range(0, nearRedButton.Length);
			while (r == lastRedButton) {
				r = Random.Range(0, nearRedButton.Length);
			}
			lastRedButton = r;
			return r;
		} else {
			return 0;
		}

	}

	int lastCreeps = 0;
	int GetRandomCreeps()
	{
		if (creeps.Length > 1) {
			int r = Random.Range(0, creeps.Length);
			while (r == lastCreeps) {
				r = Random.Range(0, creeps.Length);
			}
			lastCreeps = r;
			return r;
		} else {
			return 0;
		}

	}
	int lastBoulders = 0;
	int GetRandomBoulders()
	{
		if (boulders.Length > 1) {
			int r = Random.Range(0, boulders.Length);
			while (r == lastBoulders) {
				r = Random.Range(0, boulders.Length);
			}
			lastBoulders = r;
			return r;
		} else {
			return 0;
		}

	}

	int lastKillCreeps = 0;
	int GetRandomKillCreeps()
	{
		if (killCreeps.Length > 1) {
			int r = Random.Range(0, killCreeps.Length);
			while (r == lastKillCreeps) {
				r = Random.Range(0, killCreeps.Length);
			}
			lastKillCreeps = r;
			return r;
		} else {
			return 0;
		}

	}
}
