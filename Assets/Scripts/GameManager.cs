using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public GameObject playerObject;
    public Button startButtton;
    public Button restartButtton;
    public Button playAgain;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI levelOneText;
    public TextMeshProUGUI scoreText;
   
    public Button goToSecondLevel;
    public int score = 0;
    void Start()
    {
        scoreText.text = "Score " + score; // initialize of score
        updateScore(0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "Score " + score; // update of scoretext
    }

    public void startGame()
    {
        // boolen statments which comes from PlayerMovement script
        playerObject.GetComponent<PlayerMovement>().isOnFinishGround = false;
        playerObject.GetComponent<PlayerMovement>().isGameActive = true;
        playerObject.GetComponent<PlayerMovement>().gameOver = false;
        startButtton.gameObject.SetActive(false);
       // Cursor.lockState = CursorLockMode.Locked; // invisibility adjusment of mouse cursor
    }
    public void gameOver() // end game
    {
        gameOverText.gameObject.SetActive(true);
        playerObject.GetComponent<PlayerMovement>().isGameActive = false;
        playerObject.GetComponent<PlayerMovement>().gameOver = true;
      
      
       
    }
    public void goToFirstScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2); // goes to First Level
        
    }
   

    public void restartGame()
    {
       
        ////playerObject.GetComponent<PlayerMovement>().isOnFinishGround = false;
        ////playerObject.GetComponent<PlayerMovement>().isGameActive = true;
        ////playerObject.GetComponent<PlayerMovement>().gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // backs to first level


    }
    public void LoadNextLeve()
    {
        goToSecondLevel.gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // increment the index of scene
    }


    public void updateScore(int scoreToAdd) // updates scores
    {
        score += scoreToAdd;
        scoreText.text = "Score " + score;
    }
}
