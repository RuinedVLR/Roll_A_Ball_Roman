using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnChosenChar : MonoBehaviour
{
    [SerializeField] private GameObject[] chars;
    public static GameObject player;

    public void Awake()
    {
        chars[SaveManager.instance.currentChar].SetActive(true);
        player = chars[SaveManager.instance.currentChar];

        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            playerInput.SwitchCurrentControlScheme("Keyboard&Mouse", Keyboard.current, Mouse.current);
        }
    }
}

