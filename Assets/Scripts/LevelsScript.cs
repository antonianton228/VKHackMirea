using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsScript : MonoBehaviour
{
    public void Scenes(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
