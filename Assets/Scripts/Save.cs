using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Save
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created

	public List<String> MapsPathsList;
	public int current_level;
	public int max_level;
	public int max_opened_level;
	
	public int score;
	
	public bool is_auth;
	
	public string vkid;
	
}
