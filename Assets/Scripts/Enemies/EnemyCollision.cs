using UnityEngine;
using System.Collections;

public class EnemyCollision: MonoBehaviour
{
	public EnemyControl ec;
	
	private void OnCollisionStay2D(Collision2D collision)
	{
		ec.PhysicalCollision(collision);
	}
}
