using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopBack : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
