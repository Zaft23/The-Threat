using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject AudioSetting;


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void ToggleOnAudioSetting()
    {
        AudioSetting.SetActive(true);
        Cursor.visible = true;

    }
    public void ToggleOffAudioSetting()
    {
        AudioSetting.SetActive(false);
    }











}
