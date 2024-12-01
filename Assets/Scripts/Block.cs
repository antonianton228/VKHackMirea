using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] private float hp;
	[SerializeField] private float protection;
	[SerializeField] public GameController controller;
	[SerializeField] public int points_for_break = 0;
	
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		check_state();
	}
	
	private void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.tag == "fish")
		{
			FlyingFish fish = other.transform.GetComponent<FlyingFish>();
			hp = hp - (fish.get_damage() * protection);
		}
		
	}
	
	private void check_state(){
		if (hp < 0)
		{
			distructive();
		}
	}
	
	private void distructive()
	{
		controller.current_score += points_for_break;

		Destroy(gameObject);
	}
	
}
