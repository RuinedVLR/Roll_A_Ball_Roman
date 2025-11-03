using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LVLupMenu.magnetLvl = 1;
        LVLupMenu.speedLvl = 1;
        LVLupMenu.fireRateLvl = 1;
        LVLupMenu.firePowerLvl = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
