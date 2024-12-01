using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeaderboardManagerScript : MonoBehaviour
{
	[SerializeField] private GameObject entryPrefab;
	[SerializeField] private Transform content;
	
	private List<GameObject> table = new List<GameObject>();
	
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
		
		
		foreach (GameObject tab in table){
			Destroy(tab);

		}

		foreach (var leader in leaders)
		{
			GameObject entry = Instantiate(entryPrefab, content);
			table.Add(entry);
			entry.GetComponent<LeaderboardEntryScript>().SetEntry(leader.name, leader.score);
		}
		is_inited = true;
		
	}
	
	public void create_list(List<UserScoreboard> scoreboard)
	{
		foreach(UserScoreboard user in scoreboard)
		{
			leaders.Add((user.name, user.score));
		}
	}
	
	
	
}
