using UnityEngine;

public class SpawnChosenChar : MonoBehaviour
{
    [SerializeField] private GameObject[] chars;
    public static GameObject player;

    public void Awake()
    {
        chars[SaveManager.instance.currentChar].SetActive(true);
        player = chars[SaveManager.instance.currentChar];
    }
}
