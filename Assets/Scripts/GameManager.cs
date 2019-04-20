using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject audioSource;
    private int numberCoinsCollected;
    AudioSource[] audio;
    bool naranja, paella, petardo;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource _music = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
        if(!_music.isPlaying) _music.Play();
        numberCoinsCollected = 0;
        audio = GetComponents<AudioSource>();
        naranja = false; paella = false;  petardo = false;
    }

    private void CoinCollected()
    {
        ++numberCoinsCollected;
        audio[0].Play();
    }

    public int getCoinsCollected()
    {
        return numberCoinsCollected;
    }

    public void ObjectCollected(string tag)
    {
        switch (tag)
        {
            case "naranja":
                naranja = true;
                Debug.Log("You have found the Orange");
                break;
            case "petardo":
                petardo = true;
                Debug.Log("You have found the Firecracker");
                break;
            case "paella":
                paella = true;
                Debug.Log("You have found the Paella");
                break;
        }
        audio[1].Play();
        if (paella && petardo && naranja)
        {
            Debug.Log("Great! You found all the objects. Go to the final!");
        }
        
    }

    public bool isReady()
    {
        return paella && petardo && naranja;
    }

}
