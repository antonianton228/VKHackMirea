using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	
	[SerializeField] private List<FlyingFish> fishes;
	[SerializeField] private int currentFish;
	[SerializeField] private bool is_game_ended;
	
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		fishes[currentFish].init_fish();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	public void use_ability()
	{
		fishes[currentFish - 1].use_ability();
	}
	
	public void shoot(Vector2 speed)
	{
		if(!is_game_ended)
		{
			Debug.Log(speed.magnitude);
			if (speed.magnitude > 3)
			{
				GetComponent<Player>().status = 1;
				fishes[currentFish].start_fly(speed);
				next_fish();
			}
		}
		
	}
	
	public void show_line(Vector2 speed)
	{
		if(!is_game_ended)
		{
			fishes[currentFish].drow_line(speed);
		}
		
		
	}
	public void hide_line(){
		if(!is_game_ended)
		{
			fishes[currentFish].delete_line();
			
		}
	}
	
	private void next_fish()
	{
		currentFish += 1;
		if (currentFish == fishes.Count)
		{
			is_game_ended = true;
			return;
		}
		fishes[currentFish].init_fish();
	}
}
