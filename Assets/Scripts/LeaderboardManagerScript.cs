using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeaderboardManagerScript : MonoBehaviour
{
	[SerializeField] private GameObject entryPrefab;
	[SerializeField] private Transform content;
	
	private bool is_inited = false;

	private List<(string name, int score)> leaders = new List<(string, int)>
	{
		// ("aaaa", 1488),
		// ("bbbb", 150),
		// ("cccc", 120),
		// ("dddd", 100),
	};

	void Start()
	{
	}
	
	public void init_board()
	{
		if (!is_inited)
		{
			foreach (var leader in leaders)
			{
				GameObject entry = Instantiate(entryPrefab, content);
				entry.GetComponent<LeaderboardEntryScript>().SetEntry(leader.name, leader.score);
			}
			is_inited = true;
		}
	}
	
	public void create_list(List<UserScoreboard> scoreboard)
	{
		foreach(UserScoreboard user in scoreboard)
		{
			leaders.Add((user.name, user.score));
		}
	}
	
	
	
}
