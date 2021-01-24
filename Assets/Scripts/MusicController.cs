using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource winMusic;
    public AudioSource loseMusic;
    private WillowController willowController; // this line of code creates a variable called "willowController" to store information about the WillowController script!

    // Start is called before the first frame update
    void Start()
    {
        GameObject willowControllerObject = GameObject.FindWithTag("Willow"); //this line of code finds the RubyController script by looking for a "RubyController" tag on Ruby
        if (willowControllerObject != null)
        {
            willowController = willowControllerObject.GetComponent<WillowController>(); //and this line of code finds the rubyController and then stores it in a variable
            print ("Found the RubyController Script!");
        }
        if (willowController == null)
        {
            print ("Cannot find GameController Script!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (willowController.currentTime < 13 && willowController.currentTime > 0 && willowController.score == 0)
        {
            loseMusic.enabled = false;
            backgroundMusic.enabled = true;
            winMusic.enabled = false;
        }

        if (willowController.score == 5)
        {
            loseMusic.enabled = false;
            backgroundMusic.enabled = false;
            winMusic.enabled = true;
        }

        if (willowController.currentTime == 0)
        {
            loseMusic.enabled = true;
            backgroundMusic.enabled = false;
            winMusic.enabled = false;
        } 
    }
}


