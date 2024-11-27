using UnityEngine;

public class Seahorse : FlyingFish
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	
   override public void use_ability()
   {
   	if (can_use_ability)
		{
			rb.gravityScale = 1;
			gravity = 1;
			can_use_ability = false;
		}
		
   }
}
