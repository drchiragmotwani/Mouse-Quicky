using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFieldSpawner : MonoBehaviour
{
    public GameObject leftField;
    private GameManagerScript gameManager;
    public float leftFieldSpawnRate = 3.73f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        SpawnLeftField();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOn)
        {
            if (timer < leftFieldSpawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                // spawn bridge
                SpawnLeftField();
                // set timer back to zero
                timer = 0;
            }
        }
    }

    private void SpawnLeftField()
    {
        Instantiate(leftField, transform.position, transform.rotation);
    }
}
