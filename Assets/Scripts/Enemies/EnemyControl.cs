using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyControl: MonoBehaviour
{
	public music musicID;

	//variables for all
	private GameObject target;
	private Settings settings;
	private bool converted = false;
	private music convertedID = music.none;
	public Health myHealth;

	public CircleCollider2D viewingArea;
	public float viewingRadius = 5f;
	
	public Rigidbody2D rb;

	private Vector2 dir;

	//variables for none

	//variables for follow
	private bool targetFound = false;
	public float speed = 100f;
	public float followDamage = 1f;

	//variables for explode

	private void Start()
	{
		settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
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
		myHealth.health = 1f;
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
		bool playerCollision = collision.gameObject.CompareTag("Player");
		bool convertedCollision = collision.gameObject.CompareTag("Converted");
		bool enemyCollision = collision.gameObject.CompareTag("Enemy");
		if (!targetFound && ((!converted && (playerCollision || convertedCollision)) || (converted && (convertedCollision || enemyCollision))))
		{
			target = collision.gameObject;
			targetFound = true;
		}
	}

	public void Convert(music id)
	{
		targetFound = false;
		converted = true;
		gameObject.transform.GetChild(0).tag = "Converted";
		convertedID = id;
	}

	public void PhysicalCollision(Collision2D collision)
	{
		switch (musicID)
		{
			case music.none:
				break;
			case music.follow:
				PhysicalCollisionFollow(collision);
				break;
			case music.explode:
				break;
			default:
				break;
		}
	}

	public void PhysicalCollisionFollow(Collision2D collision)
	{
		bool playerCollision = ((collision.gameObject.transform.childCount > 0) ? collision.gameObject.transform.GetChild(0).CompareTag("Player"):false);
		bool convertedCollision = ((collision.gameObject.transform.childCount > 0) ? collision.gameObject.transform.GetChild(0).CompareTag("Converted") : false);
		bool enemyCollision = ((collision.gameObject.transform.childCount > 0) ? collision.gameObject.transform.GetChild(0).CompareTag("Enemy") : false);
		if (targetFound && ((!converted && (playerCollision || convertedCollision)) || (converted && (convertedCollision || enemyCollision))))
		{
			Debug.Log(collision.gameObject.tag);
			Health h = target.GetComponentInParent	<Health>();
			h.DealDamage(followDamage);
			myHealth.EnemyDie();
		}
	}
}
