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
		winCanvas.SetActive(true);
	}
	
	public void show_loose_canvs()
	{
		looseCanvas.SetActive(true);
	}
	
	public void to_main_menu()
	{
		SceneManager.LoadScene("Menu");
	}
	
	public void next_level()
	{
		Save save = GetComponent<GameController>().save;
		save.current_level += 1;
		save.current_level = math.min(save.current_level, save.max_level);
		save.max_opened_level = math.max(save.current_level, save.max_opened_level);
		
		File.WriteAllText("Assets/Save.json", JsonUtility.ToJson(save));
		
		
		SceneManager.LoadScene("CrashScene");
	}
}
