using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpawner : MonoBehaviour
{
    public GameObject bridge;
    private GameManagerScript gameManager;
    private float bridgeSpawnRate = 3.73f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        SpawnBridge();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOn)
        {
            if (timer < bridgeSpawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                // spawn bridge
                SpawnBridge();
                // set timer back to zero
                timer = 0;
            }
        }
    }

    private void SpawnBridge()
    {
        Instantiate(bridge, transform.position, transform.rotation);
    }
}
