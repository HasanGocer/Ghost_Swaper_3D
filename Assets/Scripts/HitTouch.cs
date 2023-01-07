using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival"))
        {

        }
    }
}
