using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyControl: MonoBehaviour
{
	public music musicID;

	//variables for all
	public GameObject player;
	public Settings settings;

	public CircleCollider2D viewingArea;
	public float viewingRadius = 5f;
	
	public Rigidbody2D rb;

	private Vector2 dir;

	//variables for none

	//variables for follow
	private bool playerFound = false;
	public float speed = 100f;

	//variables for explode

	private void Start()
	{
		musicID = settings.levelMusicId;

		switch (musicID)
		{
			case music.none:
				StartNone();
				break;
			case music.follow:
				StartFollow();
				break;
			case music.explode:
				StartExplode();
				break;
			default:
				StartNone();
				break;
		}
	}
	private void StartNone()
	{
		
	}
	private void StartFollow()
	{
		viewingArea.radius = viewingRadius;
	}
	private void StartExplode()
	{

	}

	private void FixedUpdate()
	{
		switch (musicID)
		{
			case music.none:
				ControlNone();
				break;
			case music.follow:
				ControlFollow();
				break;
			case music.explode:
				ControlExplode();
				break;
			default:
				ControlNone();
				break;
		}
	}
	private void ControlNone()
	{

	}
	private void ControlFollow()
	{
		if(playerFound)
		{
			dir = player.transform.position - transform.position;
			dir = Vector2.ClampMagnitude(dir, 1);
			rb.velocity = dir * speed * Time.fixedDeltaTime;
		}
	}
	private void ControlExplode()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		switch (musicID)
		{
			case music.none:
				break;
			case music.follow:
				TriggerFollow(collision);
				break;
			case music.explode:
				break;
			default:
				break;
		}
	}
	private void TriggerFollow(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			playerFound = true;
		}
	}
}
