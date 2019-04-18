using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPopup : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject audio;
    float time;
    void Start()
    {
        gameObject.SetActive(false);
        audio = GameObject.FindGameObjectWithTag("music");
        time = Time.timeScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
