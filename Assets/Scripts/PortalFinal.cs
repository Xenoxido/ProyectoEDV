using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalFinal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private WinPopup win;
    [SerializeField] private AudioClip victoryMusic;
    private AudioSource music;
    private AudioSource final;
    private GameManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        music = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
        final = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (manager.isReady())
            {
                music.Stop();
                final.PlayOneShot(victoryMusic);
                win.showWinPanel();
            }
            else
            {
                Debug.Log("You haven't found all the objects.");
            }
        }
    }
}
