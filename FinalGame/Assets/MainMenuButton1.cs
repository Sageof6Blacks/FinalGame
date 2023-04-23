using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton1 : MonoBehaviour
{
    public void PlayGame1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void QuitGame1()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }


    }

 
