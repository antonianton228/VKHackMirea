using NUnit.Framework.Internal.Filters;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class FlyingFish : MonoBehaviour
{
	[SerializeField]public float x_speed;
	[SerializeField]public float y_speed;
	[SerializeField]private float damage;
	[SerializeField]public float gravity;
	
	[SerializeField] private GameObject octopus;
	
	[SerializeField] private float swipeDistance;
	[SerializeField] private bool is_active;
	[SerializeField]private bool is_on_octopus = false;
	
	[SerializeField] public float jump_to_octopus_speed;
	
	[SerializeField] public bool can_use_ability = true;
	[SerializeField] public GameController controller;
	
	[SerializeField] public int points_for_save;
	
	
	public Rigidbody2D rb;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	virtual public void Start()
	{
		rb.gravityScale = 0;
	}

	public void turnOnOfCollider(bool mode)
	{
		if (mode)
		{
			foreach(Collider2D col in GetComponents<Collider2D>())
			{
				col.enabled = false;
			}
		}
		else
		{
			foreach(Collider2D col in GetComponents<Collider2D>())
			{
				col.enabled = true;
			}
		}
	}
	// Update is called once per frame
	virtual public void Update()
	{
		x_speed = rb.linearVelocityX;
		y_speed = rb.linearVelocityY;
		
		set_rotation();
	}
	
	public void set_rotation()
	{
		Vector2 speed_vector = rb.linearVelocity;
		float angle = Vector2.Angle(speed_vector, new Vector2(1, 0)) * math.abs(speed_vector.y) / speed_vector.y;
		transform.eulerAngles = new Vector3(0, 0, angle);
	}
	
	virtual public void use_ability()
	{
		if (can_use_ability)
		{
			
			GetComponentInChildren<SpriteRenderer>().color = Color.gray;
			can_use_ability = false;
		}
		
	}
	
	private void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.transform.tag == "block")
		{
			if (can_use_ability)
			{
				controller.next_fish();
			}
			can_use_ability = false;
			
			
			
		}
	}
	
	public void go_to_octopus()
	{
		if (rb.gravityScale == 0 && is_active && !is_on_octopus)
		{
			transform.position = Vector3.Lerp(transform.position, octopus.transform.position, jump_to_octopus_speed);
		}
		if((transform.position - octopus.transform.position).magnitude < 0.001f)
		{
			
			is_on_octopus = true;
		}
	}
	
	public void init_fish()
	{
		is_active = true;	
		// transform.position = octopus.transform.position;
		// rb.MovePosition(octopus.transform.position);
	}
	
	public float get_damage()
	{
		return damage * rb.linearVelocity.magnitude;
	}
	
	public void start_fly(Vector2 speed)
	{
		rb.gravityScale = gravity;
		rb.linearVelocity = speed;
	}
	
	public void drow_line(Vector2 speed)
	{
		//is_on_octopus = true;
		  LineDrow line = GetComponentInChildren<LineDrow>();
		  
		  	line.drow(speed);
		  
			
			// Vector3 swiped_pos = transform.position - new Vector3(swipeDistance * speed.x, swipeDistance * speed.y, 0) ;
			// GetComponentInChildren<SpriteRenderer>().transform.position = swiped_pos;
			// octopus.transform.position = swiped_pos;
			// octopus.transform.eulerAngles = new Vector3(0, 0, Vector2.Angle(speed, new Vector2(1, 0)) * (speed.y / math.abs(speed.y)));
			
		
	}
	
	
	public void delete_line()
	{
			GetComponentInChildren<LineDrow>().delete_line();
			GetComponentInChildren<SpriteRenderer>().transform.position = transform.position;
			
	}
}

