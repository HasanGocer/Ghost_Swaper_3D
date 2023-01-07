using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private int _OPArrowCount;
    [SerializeField] private GameObject _handPos;


    public IEnumerator HitPlayer(GameObject target, float speed)
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(_OPArrowCount);
        obj.transform.position = _handPos.transform.position;

        // Calculate the velocity vector for the object
        Vector3 velocity = CalculateVelocity(obj, target.transform.position, transform.position, speed);

        // Check if the velocity vector is valid before assigning it to the Rigidbody
        if (!float.IsNaN(velocity.x) && !float.IsNaN(velocity.y) && !float.IsNaN(velocity.z))
        {
            obj.GetComponent<Rigidbody>().velocity = velocity;
        }
        else
        {
            Debug.LogError("Invalid velocity vector: " + velocity);
        }

        yield return new WaitForSeconds(6f);
        ObjectPool.Instance.AddObject(_OPArrowCount, obj);
    }

    // This function calculates the velocity vector for the object to be thrown towards the target point
    Vector3 CalculateVelocity(GameObject obj, Vector3 target, Vector3 origin, float speed)
    {
        obj.transform.LookAt(target);
        // Calculate the distance and height to the target point
        float distance = Vector3.Distance(origin, target);
        float height = Mathf.Abs(target.y - origin.y);  // take the absolute value of the height

        // Check if the distance is not zero to avoid a divide-by-zero error
        if (distance > 0)
        {
            // Calculate the angle (in radians)
            float radians = Mathf.Asin((height / distance));

            // Calculate the velocity vector and return it
            float velocity = Mathf.Sqrt((0.5f * Physics.gravity.magnitude * Mathf.Pow(distance, 2)) / (Mathf.Sin(2 * radians) * distance));
            return velocity * (target - origin).normalized * speed;
        }
        else
        {
            Debug.LogError("Invalid distance: " + distance);
            return Vector3.zero;
        }
    }



}
