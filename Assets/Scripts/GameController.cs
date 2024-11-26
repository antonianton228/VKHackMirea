using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


public class GameController : MonoBehaviour
{
	
	[SerializeField] private List<FlyingFish> fishes;
	[SerializeField] private int currentFish;
	[SerializeField] public int status = 0; // 0 - стрелять, 1 - абилка, 2 - конец
	[SerializeField] private bool is_toched = false;
	private bool is_click_for_ability = false;
	
	
	[SerializeField] private Touch startTouch;
	[SerializeField] private Touch lastTouch;
	
	[SerializeField] private float speedFactor;
	
	public string level_json_path;
	[SerializeField] private Octopus octopus;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	
	[SerializeField] private List<GameObject> fishes_prefabs;
	[SerializeField] private List<GameObject> backgrounds;
	[SerializeField] private List<GameObject> bricks;
	
	[SerializeField] private Transform ZeroCoord;
	[SerializeField] private MapLevel map;
	
	[SerializeField] private FishHolder fishes_slot;
	[SerializeField] private float delta_x_fishes;
	
	void Start()
	{
		init_level();
		fishes[currentFish].init_fish();
		octopus.CurrentFish = fishes[currentFish];
		
	}

	// Update is called once per frame
	void Update()
	{
		input_update();
	}
	
	public void use_ability()
	{
		fishes[currentFish].use_ability();
		next_fish();
	}
	
	public void shoot(Vector2 speed)
	{
		
		octopus.change_position(octopus.octopus_start_pos);
		octopus.transform.eulerAngles = new Vector3(0, 0, 0);
		if(status != 2)
		{
			
			if (speed.magnitude > 3)
			{
				octopus.is_magnite = false;
				status = 1;
				fishes[currentFish].start_fly(speed);
				//next_fish();
			}
			
		}
		
	}
	
	public void show_line(Vector2 speed)
	{
		if(status != 2)
		{
			fishes[currentFish].drow_line(speed);
		}
		
		
	}
	public void hide_line(){
		if(!(status == 2))
		{
			fishes[currentFish].delete_line();
			
		}
	}
	
	public void next_fish()
	{
		currentFish += 1;
		if (currentFish == fishes.Count)
		{
			status = 2;
			return;
		}
		status = 0;
		fishes[currentFish].init_fish();
		
		
		
		octopus.CurrentFish = fishes[currentFish];
		octopus.is_magnite = true;
		fishes_slot.target = fishes_slot.target + new Vector3(delta_x_fishes * 2, 0, 0);
	}

	private void input_update()
	{
		if(status == 0)
		{
			if (Input.touchCount == 1)
			{
				if (is_click_for_ability)
				{
					is_toched = false;
					// startTouch = Input.GetTouch(0);
					// is_toched = true;
			}
				else if (!is_toched)
				{
					startTouch = Input.GetTouch(0);
					is_toched = true;
				}
				else
				{
					is_toched = true;
					lastTouch  = Input.GetTouch(0);
					Vector2 speedVector = startTouch.position - lastTouch.position;
					
					show_line(speedVector * speedFactor);
					octopus.change_position(speedVector);
					
				}
			}
			else if (Input.touchCount == 0)
			{
				is_click_for_ability = false;
				if (is_toched)
				{
					hide_line();
					Vector2 speedVector = startTouch.position - lastTouch.position;
					shoot(speedVector * speedFactor);
					
					is_toched = false;
				}
				
			}
		}
		else if(status == 1)
		{
			if (Input.touchCount == 1)
			{
				use_ability();
				status = 0;
				is_click_for_ability = true;
			}
		}
	}

	private void init_level()
	{
		string json = File.ReadAllText("Assets/MAPS/" + level_json_path);
		map =  JsonUtility.FromJson<MapLevel>(json);
		
		foreach(Break block in map.map)
		{
			GameObject obj = Instantiate(bricks[block.type], new Vector3(ZeroCoord.position.x + block.x, ZeroCoord.position.y + block.y, ZeroCoord.position.z), Quaternion.identity);
			obj.transform.eulerAngles = new Vector3(0, 0, block.angle);
		}
		int counter = 0;
		foreach(int fish in map.fishes)
		{
			GameObject obj = Instantiate(fishes_prefabs[fish], new Vector3(fishes_slot.transform.position.x - counter * delta_x_fishes, fishes_slot.transform.position.y, fishes_slot.transform.position.z), Quaternion.identity);
			counter += 1;
			obj.transform.SetParent(fishes_slot.transform);
			FlyingFish fish_script = obj.GetComponentInChildren<FlyingFish>();
			fish_script.controller = this;
			fishes.Add(fish_script);
		}
		
		
	}

}

