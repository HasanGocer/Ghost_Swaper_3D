using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTouchCharacter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival"))
        {

        }
        else if (other.CompareTag("Main"))
        {

        }
    }
}
