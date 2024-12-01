using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class LineDrow : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] private int dots_count;
	[SerializeField] private float dots_distance;
	[SerializeField] private GameObject dotPrefab;
	[SerializeField] private List<GameObject> dotsList;
	[SerializeField] private float g;
	private Vector3 g_vector;
	
	public Vector2 last_speed_vector;
	
	void Start()
	{
		g_vector = new Vector3(0, g, 0);
		
		for (int i = 1; i <= dots_count; i++)
		{
			GameObject dot = Instantiate(dotPrefab, transform.position, Quaternion.identity);
			dotsList.Add(dot);
		}
		
		delete_line();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	public void drow(Vector3 speed)
	{
		for (int i = 0; i < dots_count; i++)
		{
			//Vector2 pos = (i / (dots_count * dots_distance)) * speed + new Vector2(transform.position.x, transform.position.y);
			dotsList[i].SetActive(true);
			GameObject dot = dotsList[i];
			float t = i / (dots_count * dots_distance);
			Vector3 pos = speed * t - g_vector * t * t / 2 + transform.position;
			//Vector3 pos = new Vector3(i / (dots_count * dots_distance) * speed.x, (speed.y - g * t * t / 2), 0) + transform.position;
			//GameObject dot = Instantiate(dotPrefab);
			dot.transform.position = pos;
			//dotsList.Add(dot);
		}
		
		last_speed_vector = speed;
	}
	
	public void delete_line()
	{
		foreach(var dot in dotsList)
		{
			dot.SetActive(false);
		}
	}
}
