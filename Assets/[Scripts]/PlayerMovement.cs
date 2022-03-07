using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;

    

    float horizontalInput;
    public float horizontalMultiplier = 2;



   

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jumpForce = 350f;
    private Animator animator;
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("RunState");

    // Start is called before the first frame update

    void Start() 
    {
        animator = GetComponent<Animator>();

    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        animator.SetTrigger(runStateHash);

    }

    // Update is called once per frame
    private void Update()
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
