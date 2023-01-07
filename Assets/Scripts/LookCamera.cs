using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera, canvas;
    [SerializeField] private RivalAI rivalAI;

    public IEnumerator LookFocusCamera()
    {
        while (rivalAI.isLive)
        {
            canvas.transform.LookAt(mainCamera.transform);
            yield return new WaitForSeconds(0.4f);
        }
    }
}
