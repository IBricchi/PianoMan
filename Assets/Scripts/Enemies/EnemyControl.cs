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
	public Sprite convertedSprite;

	public CircleCollider2D viewingArea;
	
	public Rigidbody2D rb;

	private Vector2 dir;

	//variables for none

	//variables for follow
	private bool targetFound = false;
	public float speed = 100f;
	public float followDamage = 1f;
	public float viewingRadius = 10f;

	//variables for explode
	public float startCountdownRadius = 10f;
	public float maxDamageRadius = 8f;
	private float maxAttackDamage = 5f;
	public float maxCountDown = 4f;
	private float countDownTime = 0f;
	private bool readyToExplode = false;
	private bool exploding = false;
	public GameObject explosionParticles;

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
		myHealth.health = 1f;
		viewingArea.radius = startCountdownRadius;
		countDownTime = 0f;
		myHealth.deathParticles = explosionParticles;
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
		if(target == null)
		{
			targetFound = false;
		}
		if(targetFound)
		{
			dir = target.transform.position - transform.position;
			dir = Vector2.ClampMagnitude(dir, 1);
			rb.velocity = dir * speed * Time.fixedDeltaTime;
		}
	}
	private void ControlExplode()
	{
		if(readyToExplode)
		{
			countDownTime += Time.fixedDeltaTime;
			if(countDownTime >= maxCountDown)
			{
				exploding = true;
			}
		}
		if(exploding)
		{
			Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, maxDamageRadius);
			foreach(Collider2D collision in hitColliders)
			{
				bool playerCollision = collision.gameObject.CompareTag("Player");
				bool convertedCollision = collision.gameObject.CompareTag("Converted");
				bool enemyCollision = collision.gameObject.CompareTag("Enemy");
				if(playerCollision || convertedCollision || enemyCollision)
				{
					Health h = collision.gameObject.GetComponentInParent<Health>();
					h.DealDamage(maxAttackDamage);
					myHealth.EnemyDie();
				}
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		switch (musicID)
		{
			case music.none:
				break;
			case music.follow:
				TriggerFollow(collision);
				break;
			case music.explode:
				TriggerExplode(collision);
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
	private void TriggerExplode(Collider2D collision)
	{
		bool playerCollision = collision.gameObject.CompareTag("Player");
		bool convertedCollision = collision.gameObject.CompareTag("Converted");
		bool enemyCollision = collision.gameObject.CompareTag("Enemy");
		if ((!readyToExplode && !exploding) && ((!converted && (playerCollision || convertedCollision)) || (converted && (convertedCollision || enemyCollision))))
		{
			readyToExplode = true;
		}
	}

	public void Convert(music id)
	{
		targetFound = false;
		readyToExplode = false;
		converted = true;
		gameObject.transform.GetChild(0).tag = "Converted";
		convertedID = id;
		gameObject.GetComponentInChildren<SpriteRenderer>().sprite = convertedSprite;

		musicID = id;

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
		bool playerCollision = ((collision.gameObject.transform.childCount > 2) ? collision.gameObject.transform.GetChild(1).CompareTag("Player"):false);
		bool convertedCollision = ((collision.gameObject.transform.childCount > 0) ? collision.gameObject.transform.GetChild(0).CompareTag("Converted") : false);
		bool enemyCollision = ((collision.gameObject.transform.childCount > 0) ? collision.gameObject.transform.GetChild(0).CompareTag("Enemy") : false);
		
		if (targetFound && ((!converted && (playerCollision || convertedCollision)) || (converted && (convertedCollision || enemyCollision))))
		{
			Health h = collision.gameObject.GetComponentInParent<Health>();
			h.DealDamage(followDamage);
			myHealth.EnemyDie();
		}
	}
}
