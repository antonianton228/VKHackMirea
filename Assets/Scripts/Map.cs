using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using System;

[Serializable]
public struct MapLevel
{
	public List<int> fishes;
	public int background;
	public List<Break> map;
}

[Serializable]
public struct Break
{
	public int type;
	public float x;
	public float y;
	public float x_size;
	public float y_size;
	public float angle;
}