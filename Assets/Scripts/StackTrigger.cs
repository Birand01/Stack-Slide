using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTrigger : MonoBehaviour
{

   
    public GameManager gameManager;
   
    void Start()
    {
       
    }
     void Awake()
    {
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Pick")
        {
            StackManager.instance.PickUp(other.gameObject, true, "Untagged");
          
        }
       
       else if(other.tag=="Obstacle")
        {
            
            gameManager.GetComponent<GameManager>().gameOver();
          gameManager.GetComponent<GameManager>().restartGame();
        }
        
           
        
    }
}
