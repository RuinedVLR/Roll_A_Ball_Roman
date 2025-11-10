using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause UI")]
    [SerializeField] public static bool isPaused = false;
    public GameObject pauseMenuUI;

    [Header("First Selected")]
    [SerializeField] private GameObject resumeFirst;

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("resume pressed");
        pauseMenuUI.SetActive(false);
        if (!LVLupMenu.isChoosingOption)
        {
            Time.timeScale = 1f;
        }
        isPaused = false;

        EventSystem.current.SetSelectedGameObject(null);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        EventSystem.current.SetSelectedGameObject(resumeFirst);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
