using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalSeeDistance : MonoBehaviour
{
    [SerializeField] private Hit hit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival"))
        {
            StartCoroutine(hit.HitPlayer(other.gameObject));
        }
    }
}
