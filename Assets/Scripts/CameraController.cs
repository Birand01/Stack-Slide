using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;
    public float rotationSpeed;
    public GameObject playerObject;
    public Transform pivot;
    public float maxViewAngle;
    public float minViewAngle;
    void Start()
    {
        offSet = target.position - transform.position;
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (playerObject.GetComponent<PlayerMovement>().isGameActive == true && playerObject.GetComponent<PlayerMovement>().gameOver==false)
        {
            //Get the x position of the mouse & rotate the target
            float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
            target.Rotate(0, horizontal, 0);
            //Get the y position of the mouse & rotate the pivot
            float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;
            pivot.Rotate(-vertical, 0, 0);

            // Move the camera based on the current rotation of the target & the original offset
            float desiredYAngle = target.eulerAngles.y; 
            float desiredXAngle = pivot.eulerAngles.x;
            Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
            transform.position = target.position - (rotation * offSet);
            //transform.position = target.position - offSet;
            transform.LookAt(target);

            if (transform.position.y < target.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }

            //Limit up and down camera rotation
            if(pivot.rotation.eulerAngles.x> maxViewAngle && pivot.rotation.eulerAngles.x<90.0f)
            {
                pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
            }
            if (pivot.rotation.eulerAngles.x > 180.0f && pivot.rotation.eulerAngles.x <360.0f+ minViewAngle)
            {
                pivot.rotation = Quaternion.Euler(360.0f + minViewAngle, 0, 0);
            }
        }

      


     
    }

   
}
