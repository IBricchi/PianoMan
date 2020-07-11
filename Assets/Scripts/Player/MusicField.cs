using UnityEngine;
using System.Collections;

public class MusicField: MonoBehaviour
{
	music attackID = music.none;

	public void SetFieldType(music id)
	{
		attackID = id;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
		{
			collision.gameObject.GetComponentInParent<EnemyControl>().Convert(attackID);
		}
	}
}
