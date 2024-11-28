using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using System;

[Serializable]
public struct MapLevel
{
	public List<int> fishes;
	public int background;
	public int map;
}
