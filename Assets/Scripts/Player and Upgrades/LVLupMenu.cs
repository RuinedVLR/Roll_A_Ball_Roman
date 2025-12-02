using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LVLupMenu : MonoBehaviour
{
    public GameObject lvlUpMenuUI_3opt;
    public GameObject lvlUpMenuUI_2opt;
    public GameObject lvlUpMenuUI_1opt;

    public static bool isChoosingOption = false;


    public TextMeshProUGUI option1Text_3opt;
    public TextMeshProUGUI option2Text_3opt;
    public TextMeshProUGUI option3Text_3opt;

    public TextMeshProUGUI option1Text_2opt;
    public TextMeshProUGUI option2Text_2opt;

    public TextMeshProUGUI option1Text_1opt;


    public TextMeshProUGUI upgrade1Text_3opt;
    public TextMeshProUGUI upgrade2Text_3opt;
    public TextMeshProUGUI upgrade3Text_3opt;

    public TextMeshProUGUI upgrade1Text_2opt;
    public TextMeshProUGUI upgrade2Text_2opt;

    public TextMeshProUGUI upgrade1Text_1opt;


    private int option1Randomizer;
    private int option2Randomizer;
    private int option3Randomizer;

    public Image targetImage1_3opt;
    public Image targetImage2_3opt;
    public Image targetImage3_3opt;

    public Image targetImage1_2opt;
    public Image targetImage2_2opt;

    public Image targetImage1_1opt;

    private string[] optionNames = { "Magnet", "Speed Boost", "Fire Rate", "Fire Power" };
    private string[] upgradeMath = { $"Radius {Magnet.radius + magnetLvl} + 1", $"{PlayerControls.speed + speedLvl} + 1", $"{Firing.delayTime - (0.15 * fireRateLvl)}s - 0.15s", $"Radius {Firing.scale + (0.6 * firePowerLvl)} + 0.6" };
    public string[] imageNames = { "Option1IMG", "Option2IMG", "Option3IMG", "Option4IMG" };
    private Sprite[] loadedSprites;

    public static int magnetLvl;
    public static int speedLvl;
    public static int fireRateLvl;
    public static int firePowerLvl;

    public int maxMagnetLvl = 10;
    public int maxSpeedLvl = 10;
    public int maxFireRateLvl = 10;
    public int maxFirePowerLvl = 5;

    public AudioClip lvlUpClip;
    public AudioSource fixedPitch;


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
        List<int> availableOptions = new List<int>();

        if (magnetLvl < maxMagnetLvl) availableOptions.Add(0);
        if (speedLvl < maxSpeedLvl) availableOptions.Add(1);
        if (fireRateLvl < maxFireRateLvl) availableOptions.Add(2);
        if (firePowerLvl < maxFirePowerLvl) availableOptions.Add(3);

        if (availableOptions.Count >= 3)
        {
            List<int> selectedOptions = new List<int>();
            while (selectedOptions.Count < 3)
            {
                int randIndex = availableOptions[UnityEngine.Random.Range(0, availableOptions.Count)];
                if (!selectedOptions.Contains(randIndex))
                {
                    selectedOptions.Add(randIndex);
                }
            }
            option1Randomizer = selectedOptions[0];
            option2Randomizer = selectedOptions[1];
            option3Randomizer = selectedOptions[2];

            targetImage1_3opt.gameObject.SetActive(true);
            targetImage2_3opt.gameObject.SetActive(true);
            targetImage3_3opt.gameObject.SetActive(true);

            lvlUpMenuUI_3opt.SetActive(true);
            Time.timeScale = 0f;
            option1Text_3opt.text = optionNames[option1Randomizer];
            option2Text_3opt.text = optionNames[option2Randomizer];
            option3Text_3opt.text = optionNames[option3Randomizer];
            upgrade1Text_3opt.text = upgradeMath[option1Randomizer];
            upgrade2Text_3opt.text = upgradeMath[option2Randomizer];
            upgrade3Text_3opt.text = upgradeMath[option3Randomizer];
            Sprite selectedSprite1 = loadedSprites[option1Randomizer];
            Sprite selectedSprite2 = loadedSprites[option2Randomizer];
            Sprite selectedSprite3 = loadedSprites[option3Randomizer];
            Debug.Log(selectedSprite1); // Should not be null
            Debug.Log(selectedSprite2); // Should not be null
            Debug.Log(selectedSprite3); // Should not be null

            targetImage1_3opt.sprite = selectedSprite1;
            targetImage2_3opt.sprite = selectedSprite2;
            targetImage3_3opt.sprite = selectedSprite3;
            isChoosingOption = true;
            PlayerControls.isLVLup = false;
        }

        if (availableOptions.Count == 2)
        {
            List<int> selectedOptions = new List<int>();
            while (selectedOptions.Count < 2)
            {
                int randIndex = availableOptions[UnityEngine.Random.Range(0, availableOptions.Count)];
                if (!selectedOptions.Contains(randIndex))
                {
                    selectedOptions.Add(randIndex);
                }
            }
            option1Randomizer = selectedOptions[0];
            option2Randomizer = selectedOptions[1];

            targetImage1_2opt.gameObject.SetActive(true);
            targetImage2_2opt.gameObject.SetActive(true);

            lvlUpMenuUI_2opt.SetActive(true);
            Time.timeScale = 0f;
            option1Text_2opt.text = optionNames[option1Randomizer];
            option2Text_2opt.text = optionNames[option2Randomizer];
            upgrade1Text_2opt.text = upgradeMath[option1Randomizer];
            upgrade2Text_2opt.text = upgradeMath[option2Randomizer];
            Sprite selectedSprite1 = loadedSprites[option1Randomizer];
            Sprite selectedSprite2 = loadedSprites[option2Randomizer];
            Debug.Log(selectedSprite1); // Should not be null
            Debug.Log(selectedSprite2); // Should not be null

            targetImage1_2opt.sprite = selectedSprite1;
            targetImage2_2opt.sprite = selectedSprite2;
            isChoosingOption = true;
            PlayerControls.isLVLup = false;
        }

        if (availableOptions.Count == 1)
        {
            List<int> selectedOptions = new List<int>();
            while (selectedOptions.Count < 1)
            {
                int randIndex = availableOptions[UnityEngine.Random.Range(0, availableOptions.Count)];
                if (!selectedOptions.Contains(randIndex))
                {
                    selectedOptions.Add(randIndex);
                }
            }
            option1Randomizer = selectedOptions[0];

            targetImage1_1opt.gameObject.SetActive(true);

            lvlUpMenuUI_1opt.SetActive(true);
            Time.timeScale = 0f;
            option1Text_1opt.text = optionNames[option1Randomizer];
            upgrade1Text_1opt.text = upgradeMath[option1Randomizer];
            Sprite selectedSprite1 = loadedSprites[option1Randomizer];
            Debug.Log(selectedSprite1); // Should not be null
            targetImage1_1opt.sprite = selectedSprite1;
            isChoosingOption = true;
            PlayerControls.isLVLup = false;
        }
    }

    public void Option1()
    {
        lvlUpMenuUI_3opt.SetActive(false);
        lvlUpMenuUI_2opt.SetActive(false);
        lvlUpMenuUI_1opt.SetActive(false);
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

        fixedPitch.PlayOneShot(lvlUpClip, 0.7f);
    }

    public void Option2()
    {
        lvlUpMenuUI_3opt.SetActive(false);
        lvlUpMenuUI_2opt.SetActive(false);
        lvlUpMenuUI_1opt.SetActive(false);
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

        fixedPitch.PlayOneShot(lvlUpClip, 0.7f);
    }

    public void Option3()
    {
        lvlUpMenuUI_3opt.SetActive(false);
        lvlUpMenuUI_2opt.SetActive(false);
        lvlUpMenuUI_1opt.SetActive(false);
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

        fixedPitch.PlayOneShot(lvlUpClip, 0.7f);
    }
}
