using UnityEngine;
using System.Collections;

public class Health: MonoBehaviour
{
	public float health = 10f;

	public GameObject deathParticles;

	public bool player = false;

	private void FixedUpdate()
	{
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
		}
	}
	public void EnemyDie()
	{
		Instantiate(deathParticles, transform.position, transform.rotation);
		GameObject.Destroy(gameObject);
	}
}
