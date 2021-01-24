using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHit : MonoBehaviour
{
    public AudioClip birdNoise;
    private WillowController willowController;

    public BoxCollider2D collision;

    public GameObject feathersFX;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

// new variables below this line
    Rigidbody2D rb;

    public float moveSpeed;
    float xInput, yInput;

    public Rigidbody2D rigid;


    void OnTriggerEnter2D(Collider2D other)
    {
        WillowController controller = other.GetComponent<WillowController>();
        if (controller != null)
        {
            controller.PlaySound(birdNoise);
            spriteRenderer.sprite = newSprite;
            //singular new line v
            //rb.velocity = new Vector2(moveSpeed * 2, 2);
            rigid.constraints = RigidbodyConstraints2D.None;
            AddForceUp();

            GameObject feathers = Instantiate(feathersFX, transform.position, Quaternion.identity);
            controller.ChangeScore(1);
            collision.enabled = false;



            Destroy(gameObject,2f);
        }
    }


    void Start()
    {
    GameObject willowControllerObject = GameObject.FindWithTag("Willow"); //this line of code finds the RubyController script by looking for a "RubyController" tag on Ruby



    rigid = this.GetComponent<Rigidbody2D>();

    }








// new stuff below this line
    private void Awake()
    {
    rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
    xInput = Input.GetAxis("Horizontal");
    }



    void AddForceUp()
    {
        rigid.AddForce(new Vector2(8,9),ForceMode2D.Impulse);
    }
}
