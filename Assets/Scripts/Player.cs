using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;
    
    private SpriteRenderer sr;

    private Animator anim;

    private bool isGrounded = true;
    private bool moveLeft;
    private bool moveRight;
    private bool jump;

    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";
    // Start is called before the first frame update
    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        moveLeft = false;
        moveRight = false;
        jump = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();
        Debug.Log(moveLeft);
    }
    
    private void FixedUpdate() {
        PlayerMoveKeyboard();
        PlayerJump();
    }

    public void moveLeftDown() { moveLeft = true;
    }
    public void moveLeftUp() { moveLeft = false;
    }

    public void moveRightDown() { moveRight = true; }
    public void moveRightUp() { moveRight = false; }

    public void jumpDown() { jump = true; }

    private void PlayerMoveKeyboard()
    {
        
        //press keydown to move character
        if(moveLeft)
        {
            transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * moveForce; 
        }
        if(moveRight)
        transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * moveForce;
    }

    private void AnimatePlayer()
    {
        if(moveRight)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;   
        }
        else if(moveLeft)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true; 
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if(jump && isGrounded)
        {
            Debug.Log("Player Jump");
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            Debug.Log("Player Grounded");
            isGrounded = true;
        }  

        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    //get set moveLeft
    // public bool MoveLeft
    // {
    //     get { return moveLeft; }
    //     set { moveLeft = value; }
    // }

}
