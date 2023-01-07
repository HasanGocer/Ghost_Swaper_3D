using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSeeDistance : MonoBehaviour
{
    //rivalde olcak
    [SerializeField] private RivalID rivalID;
    [SerializeField] private float gunReloadTime;
    [SerializeField] private float maxDistance = 10.0f;


    public IEnumerator GunFire(GameObject main)
    {
        rivalID.rivalAI.isSeeMain = true;
        StartCoroutine(rivalID.hit.HitPlayer(main.gameObject, 10));
        yield return new WaitForSeconds(gunReloadTime);
        rivalID.rivalAI.isSeeMain = false;
    }

    public IEnumerator MainSeeRaycast()
    {
        yield return null;
        while (rivalID.rivalAI.isLive)
        {
            if (rivalID.roomID.RoomActive)
            {
                Vector3 eyePosition = transform.position + Vector3.up;

                for (float angle = -150f; angle <= 150f; angle += 5f)
                {
                    Vector3 direction = transform.position;
                    Quaternion rotation = transform.rotation;
                    Vector3 eulerAngles = rotation.eulerAngles;

                    float xRad = ItemData.Instance.field.rivalDistance * 5 * Mathf.Sin(Mathf.Deg2Rad * eulerAngles.y);
                    float yRad = ItemData.Instance.field.rivalDistance * 5 * Mathf.Cos(Mathf.Deg2Rad * eulerAngles.y);
                    direction += new Vector3(ItemData.Instance.field.rivalDistance * Mathf.Sin(angle) + xRad, 0, ItemData.Instance.field.rivalDistance * Mathf.Cos(angle) + yRad);

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
