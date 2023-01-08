using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSeeDistance : MonoBehaviour
{
    //rivalde olcak
    [SerializeField] private RivalID rivalID;
    [SerializeField] private float gunReloadTime = 0.3f;

    public IEnumerator GunFire(GameObject main)
    {
        rivalID.rivalAI.isSeeMain = true;
        StartCoroutine(rivalID.hit.HitPlayer(main.gameObject, 10));
        yield return new WaitForSeconds(gunReloadTime);
        rivalID.rivalAI.isSeeMain = false;
    }

    public IEnumerator MainSeeRaycast()
    {
        while (rivalID.rivalAI.isLive)
        {
            yield return null;
            if (rivalID.roomID.RoomActive)
            {
                Vector3 eyePosition = transform.position + new Vector3(0, 3, 1.5f);

                for (float angle = -150f; angle <= 150f; angle += 5f)
                {
                    Vector3 direction = transform.position;
                    Quaternion rotation = transform.rotation;
                    Vector3 eulerAngles = rotation.eulerAngles;

                    float xRad = ItemData.Instance.field.rivalDistance * 2 * Mathf.Sin(Mathf.Deg2Rad * eulerAngles.y);
                    float yRad = ItemData.Instance.field.rivalDistance * 2 * Mathf.Cos(Mathf.Deg2Rad * eulerAngles.y);
                    direction += new Vector3(ItemData.Instance.field.rivalDistance * Mathf.Sin(angle) + xRad, 0, ItemData.Instance.field.rivalDistance * Mathf.Cos(angle) + yRad);

                    if (Physics.Raycast(eyePosition, direction, out RaycastHit hitInfo, ItemData.Instance.field.rivalDistance * 2))
                    {
                        Debug.DrawLine(eyePosition, hitInfo.point, Color.red, ItemData.Instance.field.mainDistance * 3);
                        if (hitInfo.transform.gameObject.CompareTag("Main"))
                        {
                            StartCoroutine(GunFire(hitInfo.transform.gameObject));
                            yield return new WaitForSeconds(gunReloadTime);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
