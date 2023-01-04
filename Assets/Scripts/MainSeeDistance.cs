using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSeeDistance : MonoBehaviour
{
    [SerializeField] private Hit hit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Main"))
        {
            StartCoroutine(hit.HitPlayer(other.gameObject));
        }
    }
}
