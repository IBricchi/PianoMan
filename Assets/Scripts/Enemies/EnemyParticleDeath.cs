using UnityEngine;
using System.Collections;

public class EnemyParticleDeath: MonoBehaviour
{
	private float lifeTime = 0;
	public float maxLifeTime = 2f;
	
	private void FixedUpdate()
	{
		lifeTime += Time.fixedDeltaTime;
		if(lifeTime > maxLifeTime)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
