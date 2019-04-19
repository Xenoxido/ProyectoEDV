using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    GameObject audio;
    float time;
    void Start()
    {
        gameObject.SetActive(false);
        audio = GameObject.FindGameObjectWithTag("music");
        time = Time.timeScale;
        slider.value = PlayerPrefs.GetFloat("volume");
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = slider.value;
        PlayerPrefs.SetFloat("volume", AudioListener.volume);

    }

    public void show()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        
    }

    public void close()
    {
        Time.timeScale = time;
        gameObject.SetActive(false);
        
    }


    public void clickRestart()
    {
        Time.timeScale = time;
        gameObject.SetActive(false);
        SceneManager.LoadScene("edv proyecto");
    }
    public void clickMain()
    {
        Time.timeScale = time;
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void mute()
    {

        if(audio != null)
        {
            audio.SendMessage("Pause");
        }
    }


    
}
