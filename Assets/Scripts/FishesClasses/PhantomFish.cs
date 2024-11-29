using System;
using System.Diagnostics;
using UnityEngine;

public class PhantomFish : FlyingFish
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	public int counter_of_use = 0;
	private Stopwatch watch; 

	public override void Update()
	{
		base.Update();
		if (counter_of_use == 1)
		{
			if (watch.ElapsedMilliseconds > 1000)
			{
				use_ability();
				controller.status = 3;
				controller.next_fish();
				counter_of_use = 2;
			}
		}
		
	}

 	
   override public void use_ability()
   {
   		if (can_use_ability && counter_of_use == 0)
		{
			turnOnOfCollider(true);
			
			SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();

			sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
			watch = Stopwatch.StartNew();
			counter_of_use += 1;
			can_use_ability = true;
		}
		else if (can_use_ability && counter_of_use == 1)
		{
			
			turnOnOfCollider(false);
			SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
			sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 1);
			can_use_ability = false;
		}
		
	
		
   }
}
