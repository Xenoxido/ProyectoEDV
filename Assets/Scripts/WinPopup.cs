using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPopup : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.timeScale;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showWinPanel()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void onClickRestart()
    {
        Time.timeScale = time;
        gameObject.SetActive(false);
        SceneManager.LoadScene("GameLevel");
       

    }

    public void clickMain()
    {
        Time.timeScale = time;
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
