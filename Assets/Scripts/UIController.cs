using System.IO;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	
	[SerializeField] private GameObject winCanvas;
	[SerializeField] private GameObject looseCanvas;
		void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	public void show_win_canvs()
	{
		GameController controller = GetComponent<GameController>();

		controller.save.score = controller.save.score + controller.current_score;
		//File.WriteAllText("Assets/Save.json", JsonUtility.ToJson(save));
		
		
		winCanvas.SetActive(true);
	}
	
	public void show_loose_canvs()
	{
		looseCanvas.SetActive(true);
	}
	
	public void to_main_menu()
	{
		GameController controller = GetComponent<GameController>();
		Save save = controller.save;
		File.WriteAllText("Assets/Save.json", JsonUtility.ToJson(save));
		SceneManager.LoadScene("Menu");
	}
	
	public void next_level()
	{
		GameController controller = GetComponent<GameController>();
		controller.save.current_level += 1;
		controller.save.current_level = math.min(controller.save.current_level, controller.save.max_level);
		controller.save.max_opened_level = math.max(controller.save.current_level, controller.save.max_opened_level);
		
		if (controller.save.is_auth)
		{
			DBUpdate db = GetComponent<DBUpdate>();
			StartCoroutine(db.update_db(controller.save));
		}
		
		Debug.Log(controller.save.current_level);
		
		File.WriteAllText("Assets/Save.json", JsonUtility.ToJson(controller.save));

		
		SceneManager.LoadScene("CrashScene");
	}
}
