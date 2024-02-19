using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1Mover : MonoBehaviour
{
    public float speed;
    public GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.playerHitObstacle)
        {
            StopMovingObstacles();
        }
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void StopMovingObstacles()
    {
        Debug.Log("Obstacle speed: " + speed);
        if (speed != 0)
        {
            speed = speed + (Time.deltaTime * -speed);
        }
    }
}
