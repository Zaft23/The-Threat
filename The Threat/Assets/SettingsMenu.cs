using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private int currentSceneIndex;
    [SerializeField] private int sceneToContinue;
    public AudioMixer audioMixer;
    public GameObject AudioSetting;


    public void LoadMainMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(0);

    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }


    public void Continue()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if (sceneToContinue != 0)
        {
            SceneManager.LoadScene(sceneToContinue);

        }
        else
            return;



    }

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

    public void ExitGame()
    {
        Application.Quit();
    }











}
