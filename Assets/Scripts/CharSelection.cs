using UnityEngine;
using UnityEngine.UI;

public class CharSelection : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    private int currentChar;

    private void Start()
    {
        SelectChar(0);
    }

    private void SelectChar(int index)
    {
        nextButton.interactable = index < transform.childCount - 1;
        previousButton.interactable = index > 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void ChangeChar(int change)
    {
        currentChar += change;
        SelectChar(currentChar);
    }
}
