using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeaderboardManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject entryPrefab;
    [SerializeField] private Transform content;

    private List<(string name, int score)> leaders = new List<(string, int)>
    {
        ("Матвей", 1488),
        ("Антон", 150),
        ("Андрей", 120),
        ("Денис", 100),
    };

    void Start()
    {
        foreach (var leader in leaders)
        {
            GameObject entry = Instantiate(entryPrefab, content);
            entry.GetComponent<LeaderboardEntryScript>().SetEntry(leader.name, leader.score);
        }
    }
}
