using UnityEngine;
using System.Collections;

public class FirstStoryMoment : MonoBehaviour
{

	public float startGameTime;

	public Transform player;
	public Camera cinematicCamera;

	// Use this for initialization
	void Start()
	{
		Invoke("StartGame", startGameTime);
		
	}

	void StartGame()
	{
		cinematicCamera.gameObject.SetActive(false);
		player.gameObject.SetActive(true);


	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return)) {
			StartGame();
			audio.Stop();

		}
	}

}
