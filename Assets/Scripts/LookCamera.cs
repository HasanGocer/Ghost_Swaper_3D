using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera, canvas;
    [SerializeField] private RivalID rivalID;

    public IEnumerator LookFocusCamera()
    {
        while (GameManager.Instance.isStart)
        {
            yield return null;
            canvas.transform.LookAt(mainCamera.transform);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
