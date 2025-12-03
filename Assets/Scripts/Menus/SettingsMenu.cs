using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;

    private void Start()
    {
        if (SaveManager.instance != null && volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(SetVolume);
            volumeSlider.value = SaveManager.instance.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);

            if (fullscreenToggle != null)
            {
                fullscreenToggle.onValueChanged.RemoveListener(SetFullscreen);
                fullscreenToggle.isOn = SaveManager.instance.isFullscreen;
                fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
            }
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

        if (SaveManager.instance != null)
        {
            SaveManager.instance.isFullscreen = isFullscreen;
            SaveManager.instance.Save();
        }
    }

    public void ResetProgress()
    {
        SaveManager.instance.ResetProgress();
    }
}

