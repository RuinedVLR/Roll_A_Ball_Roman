using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharSelection : MonoBehaviour
{
    [Header("Navigation Buttons")]
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI priceText;

    [Header("Names Array")]
    [SerializeField] private GameObject namesArray;

    [Header("Character Prices")]
    [SerializeField] private int[] charPrices;

    private int currentChar;

    private void Start()
    {
        currentChar = SaveManager.instance.currentChar;
        SelectChar(currentChar);
    }

    private void SelectChar(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
            namesArray.transform.GetChild(i).gameObject.SetActive(i == index);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (SaveManager.instance.charsUnlocked[currentChar])
        {
            playButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            playButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
            priceText.text = "$" + charPrices[currentChar].ToString();
        }
    }

    private void Update()
    {
        if(buyButton.gameObject.activeInHierarchy)
        {
            buyButton.interactable = (SaveManager.instance.money >= charPrices[currentChar]);
        }
    }

    public void ChangeChar(int change)
    {
        currentChar += change;

        if(currentChar > transform.childCount - 1)
        {
            currentChar = 0;
        }
        else if(currentChar < 0)
        {
            currentChar = transform.childCount - 1;
        }

        SaveManager.instance.currentChar = currentChar;
        SaveManager.instance.Save();
        SelectChar(currentChar);
    }

    public void BuyChar()
    {
        int price = charPrices[currentChar];

        SaveManager.instance.money -= price;
        SaveManager.instance.charsUnlocked[currentChar] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
