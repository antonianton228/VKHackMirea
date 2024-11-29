using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public bool isOn;
    private void Start()
    {
        isOn = true;
    }

    public void OnOffMusic()
    {
        isOn = !isOn;
        if (isOn)
        {
            AudioListener.volume = 1f;
        }
        else
        {
            AudioListener.volume = 0f;
        }
    }
}
