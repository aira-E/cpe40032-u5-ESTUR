using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    private int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        //Racks up points to display in the UI.
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        //gameOverText.gameObject.SetActive(true);
    }
    public void GameOver()
    {
        //Game Over text and restart button appear
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        // Restart button work
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        // Game difficulty parameter
        spawnRate /= difficulty;

        // Make the buttons start the game
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        UpdateLives(3);
        titleScreen.gameObject.SetActive(false); 
    }
    public void UpdateLives(int livesUpdater)
    {
        //Lives updater
        lives += livesUpdater;
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            GameOver();
            livesText.text = "Lives: ";
        }
    }
}
