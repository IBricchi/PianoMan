using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
	public Rigidbody2D rb;
	public float speed = 200f;

	private Vector2 dir = Vector2.zero;

	public void FixedUpdate()
	{
		dir = Vector2.zero;

		if (Input.GetKey(KeyCode.W)) dir.y += 1;
		if (Input.GetKey(KeyCode.A)) dir.x -= 1;
		if (Input.GetKey(KeyCode.S)) dir.y -= 1;
		if (Input.GetKey(KeyCode.D)) dir.x += 1;

		dir = Vector2.ClampMagnitude(dir, 1);

		rb.velocity = dir * speed * Time.fixedDeltaTime;
	}
}
