using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	
	[SerializeField] private List<FlyingFish> fishes;
	[SerializeField] private int currentFish;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	
	public void shoot(Vector2 speed)
	{
		fishes[currentFish].start_fly(speed);
	}
	
	public void show_line(Vector2 speed)
	{
		fishes[currentFish].drow_line(speed);
	}
	public void hide_line(){
		fishes[currentFish].delete_line();
	}
}
