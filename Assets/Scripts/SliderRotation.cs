using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRotation : MonoBehaviour
{
    public Slider mySlider;
    public Transform target;
    public Vector3 offSet;
    public float rotationSpeed;
    void Start()
    {
        mySlider.onValueChanged.AddListener(delegate
        {
            Rotation();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rotation()
    {
        // Get the x position of the mouse & rotate the target

        //float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        target.Rotate(0, mySlider.value, 0);
        // Move the camera based on the current rotation of the target & the original offset
        float desiredYAngle = target.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, mySlider.value*desiredYAngle, 0);
        transform.position = target.position - (rotation * offSet);
        //transform.position = target.position - offSet;
        transform.LookAt(target);
    }
}
