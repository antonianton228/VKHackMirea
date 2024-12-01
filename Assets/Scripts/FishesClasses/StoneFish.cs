using UnityEngine;
using System.Diagnostics;
using Unity.VisualScripting;
public class StoneFish : FlyingFish
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	
	private Stopwatch watch; 
	private bool is_used = false;
	[SerializeField] private int accel_duration_ms;
	[SerializeField] private float accel_coeff;
	
	override public void Start() {
		base.Start();
		Input.gyro.enabled = true;
	}
	public override void Update()
	{
		base.Update();
		// UnityEngine.Debug.Log(Input.gyro.userAcceleration.magnitude);
		use_accel();
	}
 	
   override public void use_ability()
   {
	
	
   	if (can_use_ability)
		{
			watch = Stopwatch.StartNew();
			is_used = true;
			
			
			can_use_ability = false;
		}
		
   }
   
   private void use_accel()
   {
		if (is_used && watch.ElapsedMilliseconds < accel_duration_ms)
		{
			Vector2 accel = Input.gyro.userAcceleration;
			rb.linearVelocity = rb.linearVelocity + accel * accel_coeff;
		}
   }
   
}
