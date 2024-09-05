using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetter : MonoBehaviour
{

    public AudioSource music;
    public Slider musicSlider;


    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        music.volume = musicSlider.value;
    }
    public void SetMusicSound()
    {
        music.volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
}
