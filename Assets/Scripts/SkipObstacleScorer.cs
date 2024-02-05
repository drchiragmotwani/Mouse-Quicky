using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreScript : MonoBehaviour
{
    public GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.AddScore(1);
        }
    }
}
