using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{
    private int counter = 1;
    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;

    [SerializeField] private GameObject First;
    [SerializeField] private GameObject Second;
    [SerializeField] private GameObject Third;
    [SerializeField] private GameObject Fourth;
    [SerializeField] private GameObject Fifth;
    [SerializeField] private GameObject Sixth;
    [SerializeField] private GameObject Seventh;
    [SerializeField] private GameObject Eight;

    [SerializeField] private Image bg;

    [SerializeField] private Sprite img1;
    [SerializeField] private Sprite img2;
    [SerializeField] private Sprite img3;
    [SerializeField] private Sprite img4;
    [SerializeField] private Sprite img5;
    [SerializeField] private Sprite img6;
    [SerializeField] private Sprite img7;
    [SerializeField] private Sprite img8;

    public void ChangeR()
    {
        counter++;
        Left.SetActive(true);
        if (counter == 8)
        {
            Right.SetActive(false);
            Eight.SetActive(true);
            Seventh.SetActive(false);
            bg.sprite = img8;
        }
        if (counter == 7)
        {
            Sixth.SetActive(false);
            Seventh.SetActive(true);
            bg.sprite = img7;
        }
        if (counter == 6)
        {
            Sixth.SetActive(true);
            Fifth.SetActive(false);
            bg.sprite = img6;
        }
        if (counter == 5)
        {
            Fifth.SetActive(true);
            Fourth.SetActive(false);
            bg.sprite = img5;
        }
        if (counter == 4)
        {
            Fourth.SetActive(true);
            Third.SetActive(false);
            bg.sprite = img4;
        }
        if (counter == 3)
        {
            Third.SetActive(true);
            Second.SetActive(false);
            bg.sprite = img3;
        }
        if (counter == 2)
        {
            Second.SetActive(true);
            First.SetActive(false);
            bg.sprite = img2;
        }
    }

    public void ChangeL() 
    {
        counter--;
        Right.SetActive(true);
        if (counter == 1) 
        {  
            Left.SetActive(false);
            First.SetActive(true);
            Second.SetActive(false);
            bg.sprite = img1;
        }
        if (counter == 7)
        {
            Eight.SetActive(false);
            Seventh.SetActive(true);
            bg.sprite = img7;
        }
        if (counter == 6)
        {
            Sixth.SetActive(true);
            Seventh.SetActive(false);
            bg.sprite = img6;
        }
        if (counter == 5)
        {
            Fifth.SetActive(true);
            Sixth.SetActive(false);
            bg.sprite = img5;
        }
        if (counter == 4)
        {
            Fourth.SetActive(true);
            Fifth.SetActive(false);
            bg.sprite = img4;
        }
        if (counter == 3)
        {
            Third.SetActive(true);
            Fourth.SetActive(false);
            bg.sprite = img3;
        }
        if (counter == 2)
        {
            Second.SetActive(true);
            Third.SetActive(false);
            bg.sprite = img2;
        }
    }

    public void Start()
    {
        Left.SetActive(false);
    }
}
