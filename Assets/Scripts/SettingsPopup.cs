using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPopup : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject audio;
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    public void clickRestart()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("edv proyecto");
    }
    public void clickMain()
    {
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
