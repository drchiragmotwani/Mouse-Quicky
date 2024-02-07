using UnityEngine;

public class RightFieldSpawner : MonoBehaviour
{
    public GameObject rightField;
    private GameManagerScript gameManager;
    public float rightFieldSpawnRate = 6f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        SpawnRightField();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOn)
        {
            if (timer < rightFieldSpawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                // spawn right field
                SpawnRightField();
                // set timer back to zero
                timer = 0;
            }
        }
    }

    private void SpawnRightField()
    {
        Instantiate(rightField, transform.position, transform.rotation);
    }
}
