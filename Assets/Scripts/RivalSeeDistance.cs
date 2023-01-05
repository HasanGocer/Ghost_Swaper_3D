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
        yield return null;
        while (!isSwap)
        {
            Vector3 eyePosition = transform.position + Vector3.up;

            for (float angle = -100f; angle <= 100f; angle += 5f)
            {
                Vector3 direction = transform.position;

                Quaternion rotation = transform.rotation;
                Vector3 eulerAngles = rotation.eulerAngles;

                float xRad = 10 * Mathf.Sin(Mathf.Deg2Rad * eulerAngles.y);
                float yRad = 10 * Mathf.Cos(Mathf.Deg2Rad * eulerAngles.y);
                direction += new Vector3(2 * Mathf.Sin(angle) + xRad, 0, 2 * Mathf.Cos(angle) + yRad);

                Debug.DrawLine(eyePosition, direction, Color.red, 1f);
                RaycastHit hitInfo;
                if (Physics.Raycast(eyePosition, direction, out hitInfo, maxDistance))
                {
                    if (hitInfo.transform.gameObject.CompareTag("Rival"))
                    {
                        StartCoroutine(GunFire(hitInfo.transform.gameObject));
                        yield return new WaitForSeconds(gunReloadTime);
                    }
                }

            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
