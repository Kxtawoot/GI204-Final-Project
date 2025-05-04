using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay"); 
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit"); 
        Application.Quit();     
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("Ui_Start"); 
    }
}