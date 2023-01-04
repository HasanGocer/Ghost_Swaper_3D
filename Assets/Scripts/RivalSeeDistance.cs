using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalSeeDistance : MonoBehaviour
{
    //mainde olacak

    [SerializeField] private Hit hit;
    public bool isSwap = false;
    [SerializeField] private float gunReloadTime;
    [SerializeField] private float maxDistance = 10.0f;


    public IEnumerator GunFire(GameObject main)
    {
        StartCoroutine(hit.HitPlayer(main.gameObject));
        yield return new WaitForSeconds(gunReloadTime);
    }

    public IEnumerator MainSeeRaycast()
    {
        while (!isSwap)
        {
            Vector3 eyePosition = transform.position + Vector3.up;

            for (float angle = -50f; angle <= 50f; angle += 5f)
            {
                Vector3 direction = transform.forward;

                direction = Quaternion.Euler(0, angle, 0) * direction;

                Physics.Raycast(eyePosition, direction, out RaycastHit hitInfo, maxDistance);
                if (hitInfo.transform.gameObject.CompareTag("Rival"))
                {
                    StartCoroutine(GunFire(hitInfo.transform.gameObject));
                    yield return new WaitForSeconds(gunReloadTime);
                }
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return null;
    }
}
