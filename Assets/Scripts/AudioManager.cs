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
        //musicSlider.value = MusicDefaultVolume();

        Debug.Log($"Music slider value: {musicSlider.value}");
        Debug.Log($"Music Voulme value: { MusicDefaultVolume()}");

        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }

    public float MusicDefaultVolume()
    {
        float value;
        bool result = audioMixer.GetFloat(mixerMusic, out value);
        if (result)
            return Mathf.Log(value);
        else
        {
            return 0f;
        }
    }
   
    void ChangeMusicVolume(float value)
    {
        audioMixer.SetFloat(mixerMusic, Mathf.Log(value) * 20);
    }

    void ChangeSFXVolume(float value)
    {
        audioMixer.SetFloat(sfxMusic, Mathf.Log(value) * 20);
    }

  
}
