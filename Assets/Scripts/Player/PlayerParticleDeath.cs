using UnityEngine;
using System.Collections;

public class PlayerParticleDeath: MonoBehaviour
{
	private float lifeTime = 0;
	public float maxLifeTime = 2f;

	public LevelLoader ll;

	public void Start()
	{
		ll = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
	}

	private void FixedUpdate()
	{
		lifeTime += Time.fixedDeltaTime;
		if (lifeTime > maxLifeTime)
		{
			ll.LoadLevel(1);
			GameObject.Destroy(gameObject);
		}
	}
}
