using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject itemNotOwned;
    [SerializeField] private GameObject itemOwned;
    [SerializeField] private GameObject buyButton;
    private bool isBought;

    private void Start()
    {
        if (!isBought)
        {
            return;
        }
        
        if (isBought)
        {
            Buy();
        }
    }

    public void Buy()
    {
        itemNotOwned.SetActive(false);
        itemOwned.SetActive(true);

        buyButton.SetActive(false);

        isBought = true;
    }
}
