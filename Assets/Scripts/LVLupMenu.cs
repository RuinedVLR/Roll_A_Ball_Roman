using UnityEngine;

public class LVLupMenu : MonoBehaviour
{
    public GameObject lvlUpMenuUI;

    public static bool isChoosingOption = false;
    
    
    // Update is called once per frame
    void Update()
    {
        if (PlayerControls.isLVLup)
        {
            LvlUpOption();
        }
    }

    public void LvlUpOption()
    {
        lvlUpMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isChoosingOption = true;
        PlayerControls.isLVLup = false;
    }
    
    public void Option1()
    {
        lvlUpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isChoosingOption = false;
    }

    public void Option2()
    {
        lvlUpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isChoosingOption = false;
    }

    public void Option3()
    {
        lvlUpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isChoosingOption = false;
    }
}
