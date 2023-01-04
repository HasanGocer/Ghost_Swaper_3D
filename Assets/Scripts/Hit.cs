using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private int _OPArrowCount;
    [SerializeField] private GameObject _handPos;

    [SerializeField] private float _throwSpeed = 10.0f;

    public IEnumerator HitPlayer(GameObject target)
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(_OPArrowCount);
        obj.transform.position = _handPos.transform.position;
        obj.GetComponent<Rigidbody>().velocity = CalculateVelocity(obj, target.transform.position, transform.position);
        yield return new WaitForSeconds(6f);
        ObjectPool.Instance.AddObject(_OPArrowCount, obj);
    }

    // Bu fonksiyon, hedef noktaya do�ru at�lmas� gereken h�z vekt�r�n� hesaplar
    Vector3 CalculateVelocity(GameObject obj, Vector3 target, Vector3 origin)
    {
        obj.transform.LookAt(target);
        // Hedef noktaya olan mesafeyi ve y�ksekli�i hesaplay�n
        float distance = Vector3.Distance(origin, target);
        float height = target.y - origin.y;

        // A��y� (radyan cinsinden) hesaplay�n
        float radians = Mathf.Asin((height / distance));

        // H�z vekt�r�n� hesaplay�n ve geri d�n�n
        float velocity = Mathf.Sqrt((0.5f * Physics.gravity.magnitude * Mathf.Pow(distance, 2)) / (Mathf.Sin(2 * radians) * distance));
        return velocity * (target - origin).normalized * _throwSpeed;
    }

}
