using UnityEngine;
using System.Collections;

public class Health: MonoBehaviour
{
	public float health = 10f;
	public bool player;

	public GameObject enemyDeath;

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

	}

	public void EnemyDie()
	{
		Instantiate(enemyDeath, transform.position, transform.rotation);
		GameObject.Destroy(gameObject);
	}
}
