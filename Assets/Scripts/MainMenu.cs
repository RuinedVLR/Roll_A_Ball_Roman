using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Level");
        LVLupMenu.magnetLvl = 0;
        LVLupMenu.speedLvl = 0;
        LVLupMenu.fireRateLvl = 0;
        LVLupMenu.firePowerLvl = 0;
        PauseMenu.isPaused = false;
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LVLupMenu.magnetLvl = 0;
        LVLupMenu.speedLvl = 0;
        LVLupMenu.fireRateLvl = 0;
        LVLupMenu.firePowerLvl = 0;
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
