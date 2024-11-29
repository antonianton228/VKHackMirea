using UnityEngine;
using UnityEngine.UI;

public class MusicIcoScript : MonoBehaviour
{
    private bool muson = true;
    [SerializeField] public Sprite icon1;
    [SerializeField] public Sprite icon2;
    [SerializeField] public Button Button;
    public void Changing()
    {
        if (muson)
        {
            Button.image.sprite = icon1;
            muson = false;
        }
        else
        {
            Button.image.sprite = icon2;
            muson = true;
        }
    }
}
