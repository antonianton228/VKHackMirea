using UnityEngine;

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
}
