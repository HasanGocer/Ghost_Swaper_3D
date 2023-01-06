using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSeeDistance : MonoBehaviour
{
    //rivalde olcak
    [SerializeField] private Hit hit;
    [SerializeField] private RivalAI rivalAI;
    [SerializeField] private float gunReloadTime;
    [SerializeField] private float maxDistance = 10.0f;
    [SerializeField] private RoomID roomID;


    public IEnumerator GunFire(GameObject main)
    {
        rivalAI.isSeeMain = true;
        StartCoroutine(hit.HitPlayer(main.gameObject));
        yield return new WaitForSeconds(gunReloadTime);
        rivalAI.isSeeMain = false;
    }

    public IEnumerator MainSeeRaycast()
    {
        yield return null;
        while (rivalAI.isLive)
        {
            if (roomID.RoomActive)
            {
                Vector3 eyePosition = transform.position + Vector3.up;

                for (float angle = -50f; angle <= 50f; angle += 5f)
                {
                    Vector3 direction = transform.position;

                    Quaternion rotation = transform.rotation;
                    Vector3 eulerAngles = rotation.eulerAngles;

                    float xRad = 10 * Mathf.Sin(Mathf.Deg2Rad * eulerAngles.y);
                    float yRad = 10 * Mathf.Cos(Mathf.Deg2Rad * eulerAngles.y);
                    direction += new Vector3(2 * Mathf.Sin(angle) + xRad, 0, 2 * Mathf.Cos(angle) + yRad);

                    Debug.DrawLine(eyePosition, direction, Color.red, 1f);
                    if (Physics.Raycast(eyePosition, direction, out RaycastHit hitInfo, maxDistance))
                        if (hitInfo.transform.gameObject.CompareTag("Main"))
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
