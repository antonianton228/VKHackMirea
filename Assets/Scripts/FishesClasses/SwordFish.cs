using UnityEngine;

public class SwordFish : FlyingFish
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] private float speed_boost_coeff;
   override public void use_ability()
   {
   	if (can_use_ability)
		{
			rb.linearVelocity = rb.linearVelocity * speed_boost_coeff;
			rb.gravityScale = 0;
			gravity = 0;
			can_use_ability = false;
		}
		
   }
}
