using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Image settingsPopup;
    GameObject audio;
    AudioSource _audio;
    private void Start()
    {
        audio = GameObject.FindGameObjectWithTag("music");
        _audio = audio.GetComponent<AudioSource>();
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        _audio.Play();
        settingsPopup.gameObject.SetActive(false);
    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void OnClickCredits()
    {
        settingsPopup.gameObject.SetActive(true);        
    }

    public void OnClickClose()
    {
        settingsPopup.gameObject.SetActive(false);        
    }
    public void mute()
    {
        if (audio != null)
        {
            audio.SendMessage("Pause");
        }
    }

}
