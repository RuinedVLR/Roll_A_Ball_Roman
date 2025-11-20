using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Audio;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    public int currentChar;
    public float volume = 0f;
    public AudioMixer audioMixer;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        Load();
        ApplyVolume();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            currentChar = data.currentChar;
            volume = data.volume;

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.currentChar = currentChar;
        data.volume = volume;

        bf.Serialize(file, data);
        file.Close();
    }

    private void ApplyVolume()
    {
        if (audioMixer != null)
        {
            audioMixer.SetFloat("volume", volume);
        }
    }
}

[Serializable]
class PlayerData_Storage
{
    public int currentChar;
    public float volume;
}
