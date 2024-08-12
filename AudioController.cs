using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public float LastVolume;
    public AudioSource music;
    public Slider volumeController;
    public PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        music.volume = playerData.MusicVolume;
        volumeController.value = playerData.MusicVolume;
        LastVolume = music.volume;
    }
    // Update is called once per frame
    void Update()
    {
        music.volume = volumeController.value;
        if (music.volume != LastVolume)
        {
            LastVolume = music.volume;
            playerData.MusicVolume = music.volume;
            playerData.SavePlayerData();
        }
    }
}
