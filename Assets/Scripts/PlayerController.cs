using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using static UnityEngine.ParticleSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidBody;
    public float jumpForce;
    bool canJump;
    public GameManagerScript gameManager;
    public Animator playerAnimator;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();

        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump && !IsMouseOverUI())
        {
            // jump player
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Mobile input for jump
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && canJump)
            {
                // Construct a ray from the current touch coordinates
                playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && canJump && !IsMouseOverUI())
        {
            // dodge player to right (animation)
            playerAnimator.SetTrigger("dodged");

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bridge")
        {
            Debug.Log("Bridge Enter");
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Bridge")
        {
            Debug.Log("Bridge Exit");
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle1" || other.gameObject.tag == "Obstacle2")
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void AnimatePlayer()
    {
        if (gameManager.isGameOn)
        {
            // isMoving to true | dance to run animation
            playerAnimator.SetBool("isMoving", true);
        }
        else if (!gameManager.isGameOn)
        {
            // isMoving to fasle | run to dance animation
            playerAnimator.SetBool("isMoving", false);
        }
    }
}
