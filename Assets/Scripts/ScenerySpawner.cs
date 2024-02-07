using UnityEngine;

public class ScenerySpawner : MonoBehaviour
{
    public GameObject scenery;
    private GameManagerScript gameManager;
    public float scenerySpawnRate = 6f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        SpawnScenery();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOn)
        {
            if (timer < scenerySpawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                // spawn right field
                SpawnScenery();
                // set timer back to zero
                timer = 0;
            }
        }
    }

    private void SpawnScenery()
    {
        Instantiate(scenery, transform.position, transform.rotation);
    }
}
