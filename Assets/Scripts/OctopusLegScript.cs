using Unity.VisualScripting;
using UnityEngine;

public class OctopusLegScript : MonoBehaviour
{
	[SerializeField] private Transform octopus;
	[SerializeField] private Transform track_point;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = octopus.position;
		transform.eulerAngles = new Vector3(0, 0, 90 - Vector2.Angle(octopus.position - track_point.position, new Vector2(1, 0)));
	}
}
