using Unity.Mathematics;
using UnityEngine;

public class EnamyScript : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	public bool is_alive = true;
	[SerializeField] private float speed_for_death;
	[SerializeField] private Rigidbody2D rb;
	void Start()
	{
		rb = transform.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	private void death()
	{
		GetComponentInChildren<SpriteRenderer>().color = Color.gray;
		is_alive = false;
	}
	
	private void OnCollisionEnter2D(Collision2D other) {
		Debug.Log((other.transform.GetComponentInParent<Rigidbody2D>().linearVelocity * other.transform.GetComponentInParent<Rigidbody2D>().mass  - rb.linearVelocity * rb.mass).magnitude);
		if(other.transform.tag == "block")
		{
			if (math.abs((other.transform.GetComponentInParent<Rigidbody2D>().linearVelocity * other.transform.GetComponentInParent<Rigidbody2D>().mass  - rb.linearVelocity * rb.mass).magnitude) >= speed_for_death)
			{
				death();
			}
		}
		else if(other.transform.tag == "fish")
		{
			death();
		}
	}
}