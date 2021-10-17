using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;
    [SerializeField] private float distanceBetweenObjects;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;
    public int countPick = 0;
    public GameObject playerObject;
   public TextMeshProUGUI speedText;
    public float updatedSpeedOfPlayer=.0f;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //playerMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();
        distanceBetweenObjects = prevObject.localScale.y;
        speedText.text = "Speed " + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(GameObject pickedObject,bool needTag=false,string tag=null,bool downOrUp=true)
    {
        playerObject.GetComponent<PlayerMovement>().pickUp = true; 
        if (needTag)
        {
            pickedObject.tag = tag;

        }
        pickedObject.transform.parent = parent;
        Vector3 desiredPosition = prevObject.localPosition;
        desiredPosition.z += downOrUp ? distanceBetweenObjects : -distanceBetweenObjects;
        pickedObject.transform.localPosition = desiredPosition;
        prevObject = pickedObject.transform;
        countPick++;
       
            playerObject.GetComponent<PlayerMovement>().pickUp = true;
        updatedSpeedOfPlayer =0.5f+ 2f * Time.deltaTime * countPick;
            playerObject.transform.Translate(Vector3.forward * Time.deltaTime * updatedSpeedOfPlayer);


        countPick++;
       speedText.text = "Speed " + updatedSpeedOfPlayer;
    }

   
}
