using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSeeDistance : MonoBehaviour
{
    //rivalde olcak
    [SerializeField] private Hit hit;
    private bool isStaySee = false;
    [SerializeField] private float gunReloadTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Main"))
        {
            StartCoroutine(GunFire(other.gameObject));
            isStaySee = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Main"))
            isStaySee = false;
    }

    public IEnumerator GunFire(GameObject main)
    {
        while (isStaySee)
        {
            GetComponent<RivalAI>().isSeeMain = true;
            StartCoroutine(hit.HitPlayer(main.gameObject));
            yield return new WaitForSeconds(gunReloadTime);
        }
        GetComponent<RivalAI>().isSeeMain = false;
    }
}
