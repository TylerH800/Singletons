using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    public AudioMixer mixer;

    void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVol");
        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");

        StartCoroutine(TitleMusic());
    }

    void SetMasterVolume(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("masterVol", masterSlider.value);
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("musicVol", musicSlider.value);
    }
    void SetSFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("sfxVol", sfxSlider.value);
    }

    IEnumerator TitleMusic()
    {
        float length = AudioManager.instance.clips[5].length - 2f;
        while (true)
        {
            AudioManager.instance.PlayClip(5, AudioManager.instance.musicSource);
            yield return new WaitForSeconds(length);
        }
    }

}
