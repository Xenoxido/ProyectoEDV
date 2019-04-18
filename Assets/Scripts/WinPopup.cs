using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPopup : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {      
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showWinPanel()
    {        
        gameObject.SetActive(true);
    }

    public void onClickRestart()
    {
        SceneManager.LoadScene("edv proyecto");
        gameObject.SetActive(false);

    }

    public void clickMain()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
