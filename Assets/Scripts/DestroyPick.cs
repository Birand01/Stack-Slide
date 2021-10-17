using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // Destroying individual red cubes which attached to main player
    {
        if(other.tag=="Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
