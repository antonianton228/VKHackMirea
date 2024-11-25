using UnityEngine;


public class FlyingFish : MonoBehaviour
{
	[SerializeField]private float x_speed;
	[SerializeField]private float y_speed;
	[SerializeField]private float damage;
	[SerializeField]private float gravity;
	
	public Rigidbody2D rb;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb.gravityScale = 0;
	}

	// Update is called once per frame
	void Update()
	{
		x_speed = rb.linearVelocityX;
		y_speed = rb.linearVelocityY;
	}
	
	public float get_damage()
	{
		return damage * (rb.linearVelocity.magnitude);
	}
	
	public void start_fly(Vector2 speed)
	{
		rb.gravityScale = gravity;
		
		
		rb.linearVelocity = speed;
	}
	
	public void drow_line(Vector2 speed)
	{
		GetComponentInChildren<LineDrow>().drow(speed);
	}
	public void delete_line()
	{
		GetComponentInChildren<LineDrow>().delete_line();
	}
}

