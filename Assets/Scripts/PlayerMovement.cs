using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{

    public bool isGameActive;
    public bool hasSpeedUpGem;
    public bool isOnFinishGround;
    public bool gameOver;
    public bool pickUp;
    public float moveSpeed = 0.5f;
    private bool isOnGround = true;
    private float jumpSpeed = 20.0f;
    private float gravityModifier = 0.5f;
    StackManager stackManager;
    public GameManager gameManager;
    public TextMeshProUGUI congratsText;
    public TextMeshProUGUI badExtraPoint;
    public TextMeshProUGUI avgExtraPoint;
    public TextMeshProUGUI goodExtraPoint;
    public Button playAgain;
    public Button goToThirdLevel;
   
  
    void Start()    
    {
        Physics.gravity *= gravityModifier;
        stackManager = GetComponent<StackManager>();
        hasSpeedUpGem = false;
        isOnFinishGround = false;
        isGameActive = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       HorizontalMove();
        SpeedUpGemMove();
        morePointsOnFinalGround();
    }

   
    private void HorizontalMove()
    {
        
            


        if(isGameActive==true && gameOver==false && pickUp==false && isOnFinishGround==false) // initial start of player
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else if(isGameActive == true && gameOver == false && pickUp == true && isOnFinishGround == false) // condition that where player collects red cubes(people) in its way and speed is changing
        {
            transform.Translate(Vector3.forward * Time.deltaTime * stackManager.updatedSpeedOfPlayer);
        }
        


        if (Input.GetMouseButtonDown(0) && isOnGround && isGameActive==true && gameOver==false) // jump case of player (One click with left mouse)
            {
             transform.Translate(Vector3.up *jumpSpeed * Time.deltaTime);
            isOnGround = false;
            }

        if(transform.localPosition.y<-10)
        {
            print("Gameover");
            gameOver = true;
            isGameActive = false;
            gameManager.GetComponent<GameManager>().gameOver(); // calling gameOver function in gameManager script
            gameManager.GetComponent<GameManager>().restartGame();// calling restartGame function in gameManager script
        }




    }
    private void SpeedUpGemMove()
    {
        if (isGameActive == true && gameOver == false  && hasSpeedUpGem == true && isOnFinishGround == false) // conditions of start action
        {
            StartCoroutine(PowerUpRunGem());
            moveSpeed += 2.0f * Time.deltaTime;
            stackManager.updatedSpeedOfPlayer += 10.0f * Time.deltaTime;
            transform.Translate(Vector3.forward * Time.deltaTime * stackManager.updatedSpeedOfPlayer);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")) // case where player touches ground(trampoline)
        {
            isOnGround = true;
        }

        else if(collision.gameObject.CompareTag("SpeedUpGem")) // case where player touches SpeedUpGum
        {
           
            hasSpeedUpGem = true;
           
            
        }
        else if (collision.gameObject.CompareTag("FinalGround")) // player completes all the level (currently it stays in third level)
        {
            isOnFinishGround = true;
            congratsText.gameObject.SetActive(true);
            playAgain.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("FinalGround2")) // player arrives to third level
        {
            isOnFinishGround = true;
            goToThirdLevel.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("FinalGround3")) // player arrives to second level
        {
            isOnFinishGround = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           // gameManager.goToSecondLevel.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Point")) // colliding with point object
        {
            gameManager.updateScore(5);
        }
    }



    IEnumerator PowerUpRunGem() // 3 seconds of speed booster
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return new WaitForSeconds(3.0f);

        hasSpeedUpGem = false;
       
    }


    public void morePointsOnFinalGround()
    {
        if(transform.position.x<60 && transform.position.x>50)
        {
            badExtraPoint.gameObject.SetActive(true);
        }
        else if(transform.position.x < 49 && transform.position.x > 35)
        {
            avgExtraPoint.gameObject.SetActive(true);
        }
        else if (transform.position.x < 34)
        {
            goodExtraPoint.gameObject.SetActive(true);
        }
    }
}
