using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartPopup : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.timeScale;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickRestart()
    {        
        SceneManager.LoadScene("edv proyecto");
        gameObject.SetActive(false);
        
    }

    public void showDiedPanel()
    {        
        gameObject.SetActive(true);
    }
}
