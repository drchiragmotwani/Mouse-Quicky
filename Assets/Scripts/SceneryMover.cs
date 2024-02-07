using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryMover : MonoBehaviour
{
    public float speed;
    public GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOn)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.z < -60)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
