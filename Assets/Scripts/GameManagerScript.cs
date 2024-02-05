using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject obstacle1, obstacle2, obstacle3, playButton;
    private GameObject[] obstacles;
    public TMP_Text scorePanel;
    public Transform spawnPoint;
    public bool isGameOn = false;
    public int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new GameObject[3];

        // change from all 1 to 1-2-3 as new obstacles are added
        obstacles[0] = obstacle1;
        obstacles[1] = obstacle1;
        obstacles[2] = obstacle1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(0.7f, 2.0f);
            yield return new WaitForSeconds(waitTime);

            int obstacleNumber = Random.Range(0, 3);

            GameObject newObstacle = obstacles[obstacleNumber];
            Instantiate(newObstacle, newObstacle.transform.position, newObstacle.transform.rotation);
        }
    }

    public void GameStart()
    {
        StartCoroutine("SpawnObstacles");
        playButton.SetActive(false);
        isGameOn = true;
    }

    public void AddScore(int score)
    {
        playerScore += score;
        scorePanel.text = playerScore.ToString();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
