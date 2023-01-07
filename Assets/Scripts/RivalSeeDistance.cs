using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalSeeDistance : MonoBehaviour
{
    //mainde olacak

    public Hit hit;
    public bool isSwap = false;
    [SerializeField] private float gunReloadTime = 0.3f;

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
            Vector3 eyePosition = transform.position + Vector3.up;

            for (float angle = -150f; angle <= 150f; angle += 5f)
            {
                Vector3 direction = transform.position;

                Quaternion rotation = transform.rotation;
                Vector3 eulerAngles = rotation.eulerAngles;

                float xRad = ItemData.Instance.field.mainDistance * 5 * Mathf.Sin(Mathf.Deg2Rad * eulerAngles.y);
                float yRad = ItemData.Instance.field.mainDistance * 5 * Mathf.Cos(Mathf.Deg2Rad * eulerAngles.y);
                direction += new Vector3(ItemData.Instance.field.mainDistance * Mathf.Sin(angle) + xRad, 0, ItemData.Instance.field.mainDistance * Mathf.Cos(angle) + yRad);

                Debug.DrawLine(eyePosition, direction, Color.red, 1f);
                RaycastHit hitInfo;
                if (Physics.Raycast(eyePosition, direction, out hitInfo, ItemData.Instance.field.mainDistance * 20))
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
