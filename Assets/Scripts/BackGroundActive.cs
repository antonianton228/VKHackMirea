using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Diagnostics;
public class BackGroundActive : MonoBehaviour
{
	[SerializeField] List<GameObject> objects;
	[SerializeField] List<GameObject> current_objects;
	[SerializeField] Transform start_point;
	[SerializeField] Transform end_point;
	[SerializeField] float speed;
	[SerializeField] List<float> speed_arr;
	[SerializeField] private float delta_time_ms;
	[SerializeField] private int max_objects;
	
	private Stopwatch watch; 
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		watch = Stopwatch.StartNew();
	}

	// Update is called once per frame
	void Update()
	{
		if (watch.ElapsedMilliseconds >= delta_time_ms && current_objects.Count < max_objects)
		{
			watch = Stopwatch.StartNew();
			
			speed_arr.Add((Random.Range(0, 10) - 5f) * 0.1f * speed + speed);
			current_objects.Add(Instantiate(objects[Random.Range(0, objects.Count)], start_point.position, Quaternion.identity));
		}
		
		for(int i = 0; i < current_objects.Count; i++)
		{
			if (current_objects[i] != null)
			{
				current_objects[i].transform.position = Vector3.MoveTowards(current_objects[i].transform.position, end_point.position, speed_arr[i]);
				if ((current_objects[i].transform.position - end_point.transform.position).magnitude < 0.2)
				{
					
					Destroy(current_objects[i]);
					current_objects[i] = Instantiate(objects[Random.Range(0, objects.Count)], start_point.position, Quaternion.identity);
					speed_arr[i] = (Random.Range(0, 10) - 5f) * 0.1f * speed_arr[i] + speed_arr[i];
				}
			}
		}
		// if (current_object == null)
		// {
		// 	speed = (Random.Range(0, 2) - 1f) * 0.5f * speed + speed;
		// 	current_object = Instantiate(objects[Random.Range(0, objects.Count)], start_point.position, Quaternion.identity);
		// }
		// else
		// {
		// 	current_object.transform.position = Vector3.MoveTowards(current_object.transform.position, end_point.position, speed);
		// 	if ((current_object.transform.position - end_point.transform.position).magnitude < 0.2)
		// 	{
		// 		Destroy(current_object);
		// 		current_object = null;
		// 	}
		// }
	}
	
	
	
	
	
}
