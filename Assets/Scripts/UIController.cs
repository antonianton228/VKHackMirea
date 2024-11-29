using UnityEngine;

public class UIController : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	
	[SerializeField] private Canvas winCanvas;
	[SerializeField] private Canvas looseCanvas;
		void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	public void show_win_canvs()
	{
		winCanvas.enabled = true;
	}
	
	public void show_loose_canvs()
	{
		looseCanvas.enabled = true;
	}
}
