using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Threading;
public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidBody;
    public float jumpForce;
    bool canJump;
    public GameManagerScript gameManager;
    public Animator playerAnimator;
    public AudioSource gameOverSound;
    public AudioSource playerJumpSound;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        gameOverSound = gameManager.GetComponent<AudioSource>();
        playerJumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();

       /* if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            // jump player
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerJumpSound.Play();
        }*/

        // Mobile input for jump
        Touch touchInput = Input.GetTouch(0);
        if (touchInput.phase == TouchPhase.Began && canJump)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerJumpSound.Play();
        }

        /*foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && canJump && gameManager.isGameOn)
            {
                playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerJumpSound.Play();
            }
        }*/

        /*if (Input.GetKeyDown(KeyCode.RightArrow) && canJump && !IsMouseOverUI())
        {
            // dodge player to right (animation)
            playerAnimator.SetTrigger("dodged");

        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GroundCollider")
        {
            canJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GroundCollider")
        {
            canJump = false;
        }
    }
    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle1" || collision.gameObject.tag == "Obstacle2")
        {
            gameOverSound.Play();
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Gameplay");
        }
    }

   /* private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }*/

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
