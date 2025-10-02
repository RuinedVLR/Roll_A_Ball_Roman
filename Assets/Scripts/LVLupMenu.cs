using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class LVLupMenu : MonoBehaviour
{
    public GameObject lvlUpMenuUI;

    public static bool isChoosingOption = false;
    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;
    public TextMeshProUGUI option3Text;
    private string[] optionNames = { "Magnet", "Speed Boost", "Fire Rate", "Fire Power" };
    public GameObject magnet;
    public GameObject speedBoost;
    public GameObject fireRate;
    public GameObject firePower;
    private int option1Randomizer;
    private int option2Randomizer;
    private int option3Randomizer;


    // Update is called once per frame
    void Update()
    {
        option1Randomizer = Random.Range(0, 5);
        option2Randomizer = Random.Range(0, 5);
        option3Randomizer = Random.Range(0, 5);
        if (PlayerControls.isLVLup)
        {
            LvlUpOption();
        }
    }

    public void LvlUpOption()
    {
        lvlUpMenuUI.SetActive(true);
        Time.timeScale = 0f;
        option1Text.text = optionNames[option1Randomizer].ToString();
        option2Text.text = optionNames[option2Randomizer].ToString();
        option3Text.text = optionNames[option3Randomizer].ToString();
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
