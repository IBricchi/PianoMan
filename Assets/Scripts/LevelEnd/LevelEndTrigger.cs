using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelEndTrigger: MonoBehaviour
{
	public LevelEnd le;
	public LevelEndDir dir;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			le.Collected(dir);
		}
	}
}
