using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health: MonoBehaviour
{
	public float health = 10f;
	public float maxHealth;

	public GameObject deathParticles;
	public GameObject healthBar;

	public bool player = false;

	private int startHealthLook = 0;

	private void Awake()
	{
		maxHealth = health;
	}

	private void FixedUpdate()
	{
		if(player) ShowPlayerHealth();
		if(health <= 0)
		{
			if (player)
			{
				PlayerDie();
			}
			else
			{
				EnemyDie();
			}
		}
	}

	public void DealDamage(float damage)
	{
		health -= damage;
	}

	private void ShowPlayerHealth()
	{
		if (health < 0) health = 0;
		for(int i = startHealthLook; i < maxHealth - health; i++)
		{
			Color newColor = healthBar.transform.GetChild(i).gameObject.GetComponent<Image>().color;
			newColor.a = 0;
			healthBar.transform.GetChild(i).gameObject.GetComponent<Image>().color = newColor;
			startHealthLook = (int) (maxHealth - health);
		}
	}
	public void PlayerDie()
	{
		Instantiate(deathParticles, transform.position, transform.rotation);
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			GameObject child = gameObject.transform.GetChild(i).gameObject;
			if (child.CompareTag("Player"))
			{
				GameObject.Destroy(child);
			}
			Component.Destroy(gameObject.GetComponent<Movement>());
			Component.Destroy(gameObject.GetComponent<MusicAttack>());
			Component.Destroy(gameObject.GetComponent<Health>());
			gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}
	public void EnemyDie()
	{
		Instantiate(deathParticles, transform.position, transform.rotation);
		GameObject.Destroy(gameObject);
	}
}
