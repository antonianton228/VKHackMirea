using UnityEngine;


public class FlyingBirdScript : MonoBehaviour
{
	[SerializeField]private float x_speed;
	[SerializeField]private float y_speed;
	
	public Rigidbody2D rb;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb.linearVelocityX = x_speed;
		rb.linearVelocityY = y_speed;
	}

	// Update is called once per frame
	void Update()
	{
		x_speed = rb.linearVelocityX;
		y_speed = rb.linearVelocityY;
		
	}
}
