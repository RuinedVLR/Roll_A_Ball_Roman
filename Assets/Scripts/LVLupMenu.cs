using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LVLupMenu : MonoBehaviour
{
    public GameObject lvlUpMenuUI;

    public static bool isChoosingOption = false;

    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;
    public TextMeshProUGUI option3Text;

    private int option1Randomizer;
    private int option2Randomizer;
    private int option3Randomizer;

    public Image targetImage1;
    public Image targetImage2;
    public Image targetImage3;

    private string[] optionNames = { "Magnet", "Speed Boost", "Fire Rate", "Fire Power" };
    public string[] imageNames = { "Option1IMG", "Option2IMG", "Option3IMG", "Option4IMG" };
    private Sprite[] loadedSprites;

    public static int magnetLvl;
    public static int speedLvl;
    public static int fireRateLvl;
    public static int firePowerLvl;


    private void Start()
    {
        loadedSprites = new Sprite[imageNames.Length];

        for(int i = 0; i < imageNames.Length; i++)
        {
            loadedSprites[i] = Resources.Load<Sprite>("Images/" + imageNames[i]);
        }
    }


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
        option1Randomizer = Random.Range(0, optionNames.Length);
        while (option2Randomizer == option1Randomizer)
        {
            option2Randomizer = Random.Range(0, optionNames.Length);
        }
        while (option3Randomizer == option2Randomizer || option3Randomizer == option1Randomizer)
        {
            option3Randomizer = Random.Range(0, optionNames.Length);
        }
        
        targetImage1.gameObject.SetActive(true);
        targetImage2.gameObject.SetActive(true);
        targetImage3.gameObject.SetActive(true);


        lvlUpMenuUI.SetActive(true);
        Time.timeScale = 0f;
        option1Text.text = optionNames[option1Randomizer].ToString();
        option2Text.text = optionNames[option2Randomizer].ToString();
        option3Text.text = optionNames[option3Randomizer].ToString();
        Sprite selectedSprite1 = loadedSprites[option1Randomizer];
        Sprite selectedSprite2 = loadedSprites[option2Randomizer];
        Sprite selectedSprite3 = loadedSprites[option3Randomizer];
        Debug.Log(selectedSprite1); // Should not be null
        Debug.Log(selectedSprite2); // Should not be null
        Debug.Log(selectedSprite3); // Should not be null

        targetImage1.sprite = selectedSprite1;
        targetImage2.sprite = selectedSprite2;
        targetImage3.sprite = selectedSprite3;
        isChoosingOption = true;
        PlayerControls.isLVLup = false;
    }
    
    public void Option1()
    {
        lvlUpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isChoosingOption = false;

        if (optionNames[option1Randomizer] == "Magnet")
        {
            magnetLvl++;
        }
        else if (optionNames[option1Randomizer] == "Speed Boost")
        {
            speedLvl++;
        }
        else if (optionNames[option1Randomizer] == "Fire Rate")
        {
            fireRateLvl++;
        }
        else if (optionNames[option1Randomizer] == "Fire Power")
        {
            firePowerLvl++;
        }
    }

    public void Option2()
    {
        lvlUpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isChoosingOption = false;

        if (optionNames[option2Randomizer] == "Magnet")
        {
            magnetLvl++;
        }
        else if (optionNames[option2Randomizer] == "Speed Boost")
        {
            speedLvl++;
        }
        else if (optionNames[option2Randomizer] == "Fire Rate")
        {
            fireRateLvl++;
        }
        else if (optionNames[option2Randomizer] == "Fire Power")
        {
            firePowerLvl++;
        }
    }

    public void Option3()
    {
        lvlUpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isChoosingOption = false;

        if (optionNames[option3Randomizer] == "Magnet")
        {
            magnetLvl++;
        }
        else if (optionNames[option3Randomizer] == "Speed Boost")
        {
            speedLvl++;
        }
        else if (optionNames[option3Randomizer] == "Fire Rate")
        {
            fireRateLvl++;
        }
        else if (optionNames[option3Randomizer] == "Fire Power")
        {
            firePowerLvl++;
        }
    }
}
