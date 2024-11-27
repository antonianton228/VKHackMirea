using UnityEngine;

public class FuguFish : FlyingFish
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] private float scale_boost_coeff;
	override public void use_ability()
	{
		if (can_use_ability)
			{
				transform.localScale = transform.localScale * scale_boost_coeff;
				rb.mass = rb.mass / 2;
				//rb.linearVelocity = rb.linearVelocity / 2;
				can_use_ability = false;
			}
			
	}
}
