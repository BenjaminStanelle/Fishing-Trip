using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoGameJump : MonoBehaviour
{

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;

	Rigidbody2D rb;

	//Awake is called before first frame update
	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update()
	{
		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
			// This gives the character a conventional video game fall speed (regular gravity is "floaty")
			// Subtract 1 multiplier because we are adding to existing fall speed
		}
		else if (rb.velocity.y > 0 && !Input.GetButton ("Jump"))
        {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}
}
