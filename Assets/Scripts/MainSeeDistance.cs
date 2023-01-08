using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSeeDistance : MonoBehaviour
{
    //rivalde olcak
    [SerializeField] private float gunReloadTime = 0.3f;

    public IEnumerator GunFire(GameObject main, RivalID rivalID)
    {
        rivalID.rivalAI.isSeeMain = true;
        StartCoroutine(rivalID.hit.HitPlayer(main.gameObject, 10));
        yield return new WaitForSeconds(gunReloadTime);
        rivalID.rivalAI.isSeeMain = false;
    }

    public IEnumerator MainSeeRaycast(RivalID rivalID)
    {
        while (rivalID.rivalAI.isLive)
        {
            print(1);
            yield return null;
            if (rivalID.roomID.RoomActive)
            {
                print(2);
                Vector3 eyePosition = transform.position + new Vector3(0, 3, 1.5f);

                for (float angle = -150f; angle <= 150f; angle += 5f)
                {
                    Vector3 direction = transform.position;
                    Quaternion rotation = transform.rotation;
                    Vector3 eulerAngles = rotation.eulerAngles;

                    float xRad = ItemData.Instance.field.rivalDistance * 4 * Mathf.Sin(Mathf.Deg2Rad * eulerAngles.x);
                    float yRad = ItemData.Instance.field.rivalDistance * 4 * Mathf.Cos(Mathf.Deg2Rad * eulerAngles.x);
                    direction += new Vector3(ItemData.Instance.field.rivalDistance * Mathf.Sin(angle) + xRad, 0, ItemData.Instance.field.rivalDistance * Mathf.Cos(angle) + yRad);
                    Debug.DrawLine(eyePosition, direction, Color.red, 1);

                    if (Physics.Raycast(eyePosition, direction, out RaycastHit hitInfo, ItemData.Instance.field.rivalDistance * 4))
                    {
                        if (hitInfo.transform.gameObject.CompareTag("Main"))
                        {
                            StartCoroutine(GunFire(hitInfo.transform.gameObject, rivalID));
                            yield return new WaitForSeconds(gunReloadTime);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
