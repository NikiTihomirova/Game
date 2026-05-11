using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public ThirdPersonController player;
    public GameObject rulesPanel;

   public void StartButton()
    {
        player.canMove = true;
        gameObject.SetActive(false);
    }

    public void RulesButton()
    {
        rulesPanel.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ExitMenu()
    {
        rulesPanel.SetActive(false);
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1.0f;
    }
}
