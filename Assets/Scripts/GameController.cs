using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using System.Diagnostics;
using UnityEngine;


public class GameController : MonoBehaviour
{
	
	[SerializeField] public float current_score = 0;
	[SerializeField] private List<FlyingFish> fishes;
	[SerializeField] private int currentFish;
	[SerializeField] public int status = 0; // 0 - стрелять, 1 - абилка, 2 - конец 2, 3 - перезарядка
	
	[SerializeField] private bool is_toched = false;
	public bool is_click_for_ability = false;
	
	
	[SerializeField] private Touch startTouch;
	[SerializeField] private Touch lastTouch;
	
	[SerializeField] private float speedFactor;
	
	public string level_json_path;
	[SerializeField] private Octopus octopus;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	
	[SerializeField] private List<GameObject> fishes_prefabs;
	[SerializeField] private List<GameObject> backgrounds;
	[SerializeField] private List<GameObject> maps;
	
	[SerializeField] private Transform ZeroCoord;
	[SerializeField] private MapLevel map;
	
	[SerializeField] private FishHolder fishes_slot;
	[SerializeField] private float delta_x_fishes;
	
	[SerializeField] private Vector2 max_speed_vector;
	
	[SerializeField] public GameObject portal;
	
	[SerializeField] private bool is_win = false;	
	
	[SerializeField] private EnamyScript[] all_enamys;
	private Stopwatch watch; 
	private GameObject currentMap;
	private bool is_timer_started = false;
	
	[SerializeField] private UIController uicontroller;
	
	public Save save;
	
	void Start()
	{
		init_level();
		fishes[currentFish].init_fish();
		octopus.CurrentFish = fishes[currentFish];
		
		all_enamys = currentMap.GetComponentsInChildren<EnamyScript>();
		
		uicontroller = GetComponent<UIController>();
		
		
	}

	// Update is called once per frame
	void Update()
	{
		input_update();
		win_check();
		if (status == 2)
		{
			ender();
		}
		
	}
	
	
	private void ender()
	{
		if(!is_timer_started)
		{
			watch = Stopwatch.StartNew();
			is_timer_started = true;
		}
		else
		{
			if (is_win)
			{
				end_screen();
			}
			else if(watch.ElapsedMilliseconds > 3000)
			{
				end_screen();
			}
		}
	}
	
	
	private void end_screen()
	{
		if (is_win)
		{
			uicontroller.show_win_canvs();
		}
		else
		{
			uicontroller.show_loose_canvs();
		}
	}
	
	private void win_check()
	{
		int counter = 0;
		foreach(EnamyScript enamy in all_enamys)
		{
			if (enamy.is_alive)
			{
				counter += 1;
			}
		}
		if (counter == 0)
		{
			is_win = true;
			status = 2;
		}
	}
	
	public void use_ability()
	{
		fishes[currentFish].use_ability();
		if(fishes[currentFish] is PhantomFish)
		{
			PhantomFish pf = (PhantomFish)fishes[currentFish];
			
			if (pf.counter_of_use == 2)
			{
				status = 3;
				next_fish();
			}
			
		}
		else	
		{
			status = 3;
			next_fish();
		}
		

	}
	
	public void shoot(Vector2 speed)
	{
		octopus.change_position(octopus.octopus_start_pos);
		octopus.transform.eulerAngles = new Vector3(0, 0, 0);
		if(status != 2)
		{
			
			if (speed.x > 3)
			{
				fishes[currentFish].turnOnOfCollider(false);
				fishes[currentFish].transform.SetParent(transform);
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
		status = 3;
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

					if (speedVector.x >= max_speed_vector.x)
					{
						speedVector.x = max_speed_vector.x;
					}
					else if (speedVector.x < 50)
					{
						speedVector.x = 50;
					}
					if (speedVector.y <= -max_speed_vector.y)
					{
						speedVector.y = -max_speed_vector.y;
					}
					else if(speedVector.y >=  200)
					{
						speedVector.y = 200;
					}
					if((speedVector * speedFactor).magnitude > 3)
					{
						show_line(speedVector * speedFactor);
					}
					else
					{
						hide_line();
					}
					
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
					if (speedVector.x >= max_speed_vector.x)
					{
						speedVector.x = max_speed_vector.x;
					}
					else if (speedVector.x < 50)
					{
						speedVector.x = 50;
					}
					if (speedVector.y <= -max_speed_vector.y)
					{
						speedVector.y = -max_speed_vector.y;
					}
					else if(speedVector.y >=  200)
					{
						speedVector.y = 200;
					}
					shoot(speedVector * speedFactor);
					
					is_toched = false;
				}
				
			}
		}
		else if(status == 1)
		{
			if (Input.touchCount == 1 && !is_click_for_ability)
			{
				use_ability();
				
				is_click_for_ability = true;
			}
			else if(Input.touchCount == 0)
			{
				is_click_for_ability = false;
			}

		}
	}

	private void init_level()
	{
		string json = File.ReadAllText("Assets/Save.json");
		save = JsonUtility.FromJson<Save>(json);
		level_json_path = save.MapsPathsList[save.current_level];
		
		json = File.ReadAllText("Assets/MAPS/" + level_json_path);
		map =  JsonUtility.FromJson<MapLevel>(json);
		
		
		GameObject curr_map = Instantiate(maps[map.map], new Vector3(0, 0, 0), Quaternion.identity);
		foreach(Block blok in curr_map.GetComponentsInChildren<Block>())
		{
			UnityEngine.Debug.Log("Block");
			blok.controller = this;
		}
		
		
		currentMap = curr_map;
		int counter = 0;
		foreach(int fish in map.fishes)
		{
			GameObject obj = Instantiate(fishes_prefabs[fish], new Vector3(fishes_slot.transform.position.x - counter * delta_x_fishes, fishes_slot.transform.position.y, fishes_slot.transform.position.z), Quaternion.identity);
			
			counter += 1;
			obj.transform.SetParent(fishes_slot.transform);
			FlyingFish fish_script = obj.GetComponentInChildren<FlyingFish>();
			fish_script.controller = this;
			fish_script.turnOnOfCollider(true);
			fishes.Add(fish_script);
		}
	}

}

