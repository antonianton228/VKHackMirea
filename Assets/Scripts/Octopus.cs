using System.Globalization;
using Unity.Mathematics;
using UnityEngine;

public class Octopus : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	public Vector3 target_position;
	[SerializeField] private float speed_moving;
	[SerializeField] public float octopus_speed_factor;
	
	
	[SerializeField] public bool is_magnite = true;
	public Vector3 octopus_start_pos;
	
	public FlyingFish CurrentFish;
		void Start()
	{
		target_position = transform.position;
		octopus_start_pos = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, target_position, speed_moving);
		magnite_fish();
	}
	
	public void magnite_fish()
	{
		if (is_magnite)
		{
			CurrentFish.transform.position = Vector3.Lerp(CurrentFish.transform.position, transform.position, CurrentFish.jump_to_octopus_speed);
			if((CurrentFish.transform.position - transform.position).magnitude < 0.5)
			{
				CurrentFish.jump_to_octopus_speed = 1;
				if (CurrentFish.controller.status != 2)
				{
					CurrentFish.controller.status = 0;
				}
				 
			}
		}
		
	
	}
	
	public void change_position(Vector3 speed_vector)
	{
		target_position = octopus_start_pos - speed_vector * octopus_speed_factor;
		transform.eulerAngles = new Vector3(0, 0, Vector2.Angle(speed_vector, new Vector2(1, 0)) * (speed_vector.y / math.abs(speed_vector.y)));
		
	}
	
}
