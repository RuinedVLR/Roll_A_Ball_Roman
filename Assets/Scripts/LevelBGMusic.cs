using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class LevelBGMusic : MonoBehaviour
{
    public AudioSource bgMusic;

    // Update is called once per frame
    void Update()
    {
        if (PlayerControls.isDead)
        {
            bgMusic.Stop();
        }


    }
}
