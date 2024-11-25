using UnityEngine;

public class Player : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] private bool is_toched = false;
	[SerializeField] private Touch startTouch;
	[SerializeField] private Touch lastTouch;
	
	[SerializeField] private float speedFactor;
	private bool is_click_for_ability = false;
	
	[SerializeField] public int status = 0; // 0 - стрелять, 1 - абилка, 2 - конец
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		input_update();
	}
	
	private void input_update()
	{
		GameController controller = GetComponent<GameController>();
		if(status == 0)
		{
			if (Input.touchCount == 1)
			{
				if (!is_toched && !is_click_for_ability)
				{
					startTouch = Input.GetTouch(0);
					is_toched = true;
				}
				else
				{
					lastTouch  = Input.GetTouch(0);
					Vector2 speedVector = startTouch.position - lastTouch.position;
					controller.show_line(speedVector * speedFactor);
				}
			}
			else if (Input.touchCount == 0)
			{
				is_click_for_ability = false;
				if (is_toched)
				{
					controller.hide_line();
					Vector2 speedVector = startTouch.position - lastTouch.position;
					controller.shoot(speedVector * speedFactor);
					
					is_toched = false;
				}
				
			}
		}
		else if(status == 1)
		{
			if (Input.touchCount == 1)
			{
				GetComponent<GameController>().use_ability();
				status = 0;
				is_click_for_ability = true;
			}
		}
	}
}

