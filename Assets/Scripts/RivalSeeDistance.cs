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
        print(1);
        yield return null;
        print(2);
        while (!isSwap)
        {
            print(3);
            Vector3 eyePosition = transform.position + Vector3.up;
            print(4);

            for (float angle = -50f; angle <= 50f; angle += 5f)
            {
                print(5);
                Vector3 direction = transform.forward;

                print(6);
                direction = Quaternion.Euler(0, angle, 0) * direction;
                print(7);
                Debug.DrawLine(eyePosition, direction, Color.red, 1f);
                print(8);
                RaycastHit hitInfo;
                print(9);
                Physics.Raycast(eyePosition, direction, out hitInfo, maxDistance);
                print(10);
                if (hitInfo.transform.gameObject.CompareTag("Rival"))
                {
                    print(11);
                    StartCoroutine(GunFire(hitInfo.transform.gameObject));
                    print(12);
                    yield return new WaitForSeconds(gunReloadTime);
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
