using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Image settingsPopup;
    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickCredits()
    {
        settingsPopup.gameObject.SetActive(true);
    }

    public void OnClickClose()
    {
        settingsPopup.gameObject.SetActive(false);
    }

}
