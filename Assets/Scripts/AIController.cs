using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{

	public float rotationSpeed;
	public float movementSpeed;
	public Transform target;


	private NavMeshAgent agent;
	private Animator anim;

	// the old position
	private Vector3 oldPos;

	// Use this for initialization
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = true;
		anim = GetComponent<Animator>();
		target = GameObject.Find("Player").transform;

	}

	// Update is called once per frame
	void Update()
	{

		float speed = agent.velocity.magnitude / agent.speed;
		anim.SetFloat("Speed", speed);

		if (target)
			agent.SetDestination(target.position);


	}

}
