using System.IO;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Networking;

public class UIController : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	
	[SerializeField] private GameObject winCanvas;
	[SerializeField] private GameObject looseCanvas;
	
	[SerializeField] private string backend_adress;
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
	
	public void restart()
	{
		

		SceneManager.LoadScene("CrashScene");
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
			StartCoroutine(update_db(controller.save));
		}
		
		
		
		
		File.WriteAllText("Assets/Save.json", JsonUtility.ToJson(controller.save));
		
		SceneManager.LoadScene("CrashScene");
		
		
		
		
	}
	
	
	public IEnumerator update_db(Save save)
	{

		var uwr = new UnityWebRequest(backend_adress + "update_score", "POST");
		byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes("{\"score\":" + save.score + ", \"vk\": \"" + save.vkid + "\"}");
		uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
		uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
		uwr.SetRequestHeader("Content-Type", "application/json");

		//Send the request then wait here until it returns
		yield return uwr.SendWebRequest();


		if (uwr.isNetworkError)
		{
			Debug.Log("Error While Sending: " + uwr.error);
		}
		else
		{
			Debug.Log("Received: " + uwr.downloadHandler.text);
		}
	}
}
