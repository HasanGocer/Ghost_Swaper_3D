using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalSeeDistance : MonoBehaviour
{
    //mainde olacak

    public Hit hit;
    public bool isSwap = false;
    [SerializeField] private float gunReloadTime = 0.5f;

    public IEnumerator GunFire(GameObject main)
    {
        StartCoroutine(hit.HitPlayer(main.gameObject, ItemData.Instance.field.mainDamageSpeed));
        yield return new WaitForSeconds(gunReloadTime);
    }

    public IEnumerator MainSeeRaycast()
    {
        yield return null;
        while (!isSwap)
        {
            Vector3 eyePosition = transform.position + new Vector3(0, 3, 1.5f);

            for (float angle = -150f; angle <= 150f; angle += 5f)
            {
                Vector3 direction = transform.position;

                Quaternion rotation = transform.rotation;
                Vector3 eulerAngles = rotation.eulerAngles;

                float xRad = ItemData.Instance.field.mainDistance * 3 * Mathf.Sin(Mathf.Deg2Rad * eulerAngles.y);
                float yRad = ItemData.Instance.field.mainDistance * 3 * Mathf.Cos(Mathf.Deg2Rad * eulerAngles.y);
                direction += new Vector3(ItemData.Instance.field.mainDistance * Mathf.Sin(angle) + xRad, 0, ItemData.Instance.field.mainDistance * Mathf.Cos(angle) + yRad);

                RaycastHit hitInfo;
                if (Physics.Raycast(eyePosition, direction, out hitInfo, ItemData.Instance.field.mainDistance * 3))
                {
                    Debug.DrawLine(eyePosition, hitInfo.point, Color.red, ItemData.Instance.field.mainDistance * 3);
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
