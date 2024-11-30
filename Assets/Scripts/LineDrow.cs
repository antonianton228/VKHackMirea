using System.Collections.Generic;
using UnityEngine;

public class LineDrow : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] private int dots_count;
	[SerializeField] private float dots_distance;
	[SerializeField] private GameObject dotPrefab;
	[SerializeField] private List<GameObject> dotsList;
	[SerializeField] private float g;
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	public void drow(Vector2 speed)
	{
		delete_line();
		for (int i = 1; i <= dots_count; i++)
		{
			//Vector2 pos = (i / (dots_count * dots_distance)) * speed + new Vector2(transform.position.x, transform.position.y);
			float t = (i / (dots_count * dots_distance) * speed.x) / speed.x;
			Vector2 pos = new Vector2(i / (dots_count * dots_distance) * speed.x, speed.y * t - g * t * t / 2) + new Vector2(transform.position.x, transform.position.y);
			GameObject dot = Instantiate(dotPrefab);
			dot.transform.position = new Vector3(pos.x, pos.y, 0);
			dotsList.Add(dot);
		}
	}
	
	public void delete_line()
	{
		foreach(var dot in dotsList)
		{
			Destroy(dot);
		}
		dotsList.Clear();
	}
}
