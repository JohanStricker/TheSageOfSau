using UnityEngine;
using System.Collections;

public class StoryCameraTriggers : MonoBehaviour {

	public static StoryCameraTriggers instance;

	Camera camera;
	AudioListener listener;
	public AudioSource backgroundMusic;

	void Awake()
	{
		instance = this;
		camera = GetComponent<Camera>();
		listener = GetComponent<AudioListener>();

	}

	void Start()
	{
		GetComponent<Animator>().SetTrigger("CameraPan");

	}

	public static void ActivateComponents()
	{
		instance.camera.enabled = true;
		instance.listener.enabled = true;

	}

	public static void DeactivateComponents()
	{
		instance.camera.enabled = false;
		instance.listener.enabled = false;

	}

	public static void TriggerDeath(Transform tg) {
		instance.transform.parent = tg;
		//instance.gameObject.SetActive(true);
		instance.backgroundMusic.Stop();
		ActivateComponents();
		
		instance.GetComponent<Animator>().SetTrigger("Death");
		instance.audio.Play();
		instance.Invoke("RestartGame", 12);
		narratorVoiceScript.Say("GameOver");
	}

	void RestartGame()
	{
		Application.LoadLevel(Application.loadedLevel);
	}


}
