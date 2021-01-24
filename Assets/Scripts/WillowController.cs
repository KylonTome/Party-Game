using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WillowController : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sp;
    public float moveSpeed;
    float xInput, yInput;
    public float fallMultiplier = 2.5f;
    AudioSource audioSource;
    public int score = 0;
    public Text winLoseText;

    public float currentTime = 0f;
    float startingTime = 12f;

    public Text countdownText;

    public BoxCollider2D collision;

    public Rigidbody2D rigid;

    public AudioClip startSound;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        sp = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentTime = startingTime;

        PlaySound(startSound);
    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0");
        if (currentTime <= 0)
        {
        currentTime = 0;
        winLoseText.text = "You ran out of time! Press R to restart!";
        collision.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }


        //Added stuff!!!!!!!!!!!
        
        if (score == 5)
        {
            winLoseText.text = "Congratulations!";

            currentTime = 14;
            countdownText.text = "";
        }

        if (Input.GetKey(KeyCode.R))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // this loads the currently active scene

        }

        if (Input.GetKey("escape"))
        {
        Application.Quit();
        }

        








    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);

        PlatformerMove();
        FlipPlayer();
    }


    void PlatformerMove()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
    }

    void FlipPlayer()
    {
        if(rb.velocity.x > 0)
        {
            sp.flipX = true;
        }
        else if(rb.velocity.x < 0)
        {
            sp.flipX = false;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // Added stuff!!!!!!!!!!!!!!
     public void ChangeScore(int scoreAmount)
    {
        score += scoreAmount;
    }

}
