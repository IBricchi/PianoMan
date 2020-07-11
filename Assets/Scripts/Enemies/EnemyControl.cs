using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyControl: MonoBehaviour
{
	public music musicID;

	//variables for all
	private GameObject target;
	public Settings settings;
	private bool converted = false;
	private music convertedID = music.none;

	public CircleCollider2D viewingArea;
	public float viewingRadius = 5f;
	
	public Rigidbody2D rb;

	private Vector2 dir;

	//variables for none

	//variables for follow
	private bool targetFound = false;
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
		if(targetFound)
		{
			dir = target.transform.position - transform.position;
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
		if ((!converted && (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Converted"))) || (converted && (collision.gameObject.CompareTag("Converted") || collision.gameObject.CompareTag("Enemy"))))
		{
			target = collision.gameObject;
			targetFound = true;
		}
	}

	public void Convert(music id)
	{
		if(id != musicID)
		{
			converted = true;
			convertedID = id;
		}
	}
}
