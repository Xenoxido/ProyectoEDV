using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Text text;
    [SerializeField] private UnityEngine.UI.Image[] objects;
    // Start is called before the first frame update
    void Start()
    {
        objects[0].gameObject.SetActive(false);
        objects[1].gameObject.SetActive(false);
        objects[2].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameManager.getCoinsCollected().ToString();
    }

    public void activeImage(string tag)
    {
        switch (tag)
        {
            case "naranja":
                objects[0].gameObject.SetActive(true);
                break;
            case "paella":
                objects[1].gameObject.SetActive(true);
                break;
            case "petardo":
                objects[2].gameObject.SetActive(true);
                break;

        }
    }

}
