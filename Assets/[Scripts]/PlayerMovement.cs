using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;
    private bool moveLeft, moveRight;
    public float jumpForce = 350f;
    public Animator animator;
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("RunState");

    [Header("Onscreen Buttons")]
    public GameObject onScreenButtons;
   

    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;

    }
    public void FixedUpdate()
    {
        Move();

        if (moveLeft)
        {
            rb.velocity = new Vector3(0f, 0f, -5f);
        }
        if (moveRight)
        {
            rb.velocity = new Vector3(0f, 0f, 5f);
        }
    }

    public void Move()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        animator.SetTrigger(runStateHash);

    }

    public void MoveLeft()
    {
        moveLeft = true;
    }
    public void MoveRight()
    {
        moveRight = true;
    }
    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
        rb.velocity= new Vector3(0f, 0f,0f);
    }

    // Update is called once per frame
    public void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        horizontalInput = Input.GetAxis("Horizontal");

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        rb.AddForce(Vector3.up * jumpForce);
        animator.SetTrigger(jumpHash);
    }

    public void OnJumpButton_Pressed()
    {
        if (isGrounded)
        {
            Jump();
        }
    }

    /*
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        SceneManager.LoadScene("Main Menu Scene");
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        

        Vector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    */
}
