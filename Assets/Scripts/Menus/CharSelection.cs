using UnityEngine;
using UnityEngine.UI;

public class CharSelection : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
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
}
