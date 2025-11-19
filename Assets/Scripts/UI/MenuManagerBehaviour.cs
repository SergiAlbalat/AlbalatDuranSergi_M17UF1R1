using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerBehaviour : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado");
    }
}
