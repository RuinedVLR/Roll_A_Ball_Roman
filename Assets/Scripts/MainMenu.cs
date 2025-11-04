using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && PlayerControls.isDead == true)
        {
            Debug.Log("R key pressed");
            SceneManager.LoadScene(1);
            LVLupMenu.magnetLvl = 1;
            LVLupMenu.speedLvl = 1;
            LVLupMenu.fireRateLvl = 1;
            LVLupMenu.firePowerLvl = 1;
        }
    }

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
