using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    private void Start()
    {
        if (SaveManager.instance != null && volumeSlider != null)
        {
            volumeSlider.value = SaveManager.instance.volume;
            audioMixer.SetFloat("volume", SaveManager.instance.volume);
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);

        if (SaveManager.instance != null)
        {
            SaveManager.instance.volume = volume;
            SaveManager.instance.Save();
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
