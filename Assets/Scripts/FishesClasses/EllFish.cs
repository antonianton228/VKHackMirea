using UnityEngine;

public class EelFish : FlyingFish
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
   override public void use_ability()
   {
   	if (can_use_ability)
		{
			
			transform.position = new Vector3(controller.portal.transform.position.x, transform.position.y, 0);
			rb.linearVelocityX = -rb.linearVelocityX;
			
			can_use_ability = false;
		}
		
   }
}
