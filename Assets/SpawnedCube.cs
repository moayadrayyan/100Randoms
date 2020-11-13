using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnedCube : MonoBehaviour
{
    
    public GameObject MainPlayer;
    public AudioSource Soundclip;

    void Start()
    {
        Soundclip.playOnAwake = false;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        // check if collision happens between this object and the main player.
        if (collisionInfo.gameObject.name == "MainPlayer")
        {
            Soundclip.Play();
            var screenCanv = GameObject.Find("Alert");
            screenCanv.transform.Find("Panel").gameObject.transform.Find("Message").GetComponent<Text>().text = "Ooops ! You hit a cube, please try again.";
            screenCanv.transform.Find("Panel").gameObject.SetActive(true);
            MainPlayer.SetActive(false);            
        }
    }
}
