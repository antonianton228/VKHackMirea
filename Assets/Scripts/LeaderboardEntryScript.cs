using UnityEngine;
using UnityEngine.UI;

public class LeaderboardEntryScript : MonoBehaviour
{
    public Text nameText;
    public Text scoreText;

    public void SetEntry(string name, int score)
    {
        nameText.text = name;
        scoreText.text = score.ToString();
    }
}
