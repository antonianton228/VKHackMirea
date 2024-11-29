using UnityEngine;

public class FishHolder : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] public Vector3 target;
	[SerializeField] public float speed = 0.5f;
	void Start()
	{
		target = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, target, speed);
	}
}
