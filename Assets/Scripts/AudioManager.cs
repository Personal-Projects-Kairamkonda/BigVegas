using System.Collections.Generic;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musicSlider;
    public Slider sfxSlider;

    private const string mixerMusic = "MusicVolume";
    private const string sfxMusic = "SFXVolume";


    void Awake()
    {
        musicSlider.value = MusicDefaultVolume();
        sfxSlider.value = SFXDefaultVolume();

        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }

    //sets silder value from the volume
    public float MusicDefaultVolume()
    {
        float value;
        bool result = audioMixer.GetFloat(mixerMusic, out value);
        if (result)
        {
            return Mathf.Pow(10.0f, value / 20.0f);
        }
        else
        {
            return 0f;
        }
    }


    public float SFXDefaultVolume()
    {
        float value;
        bool result = audioMixer.GetFloat(sfxMusic, out value);
        if (result)
        {
            return Mathf.Pow(10.0f, value / 20.0f);
        }
        else
        {
            return 0f;
        }
    }

    //sets volume from the slider
    public void SetMusicVolume(float value)
    {
        
    }

    void ChangeMusicVolume(float value)
    { 
        audioMixer.SetFloat(mixerMusic, Mathf.Log10(value) * 20);
    }

    void ChangeSFXVolume(float value)
    {
        audioMixer.SetFloat(sfxMusic, Mathf.Log10(value) * 20);
    }


}
