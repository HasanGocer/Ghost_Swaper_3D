using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RivalAI : MonoBehaviour
{
    public bool isLive = true, isSeeMain;
    [SerializeField] private Ease easeType = Ease.InOutSine;
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private List<GameObject> LookTargetObjects;
    [SerializeField] private RoomID roomID;

    public void StartAI()
    {
        StartCoroutine(RunPath(objects, LookTargetObjects));
    }

    private IEnumerator RunPath(List<GameObject> objects, List<GameObject> LookTargetObjects)
    {
        GameObject firstPos, lastPos, lookPos;
        while (isLive)
        {
            if (!isSeeMain && roomID.RoomActive)
                for (int i = 0; i < objects.Count; i++)
                {
                    if (i == objects.Count - 1)
                    {
                        firstPos = objects[i];
                        lastPos = objects[0];
                        lookPos = LookTargetObjects[0];
                    }
                    else
                    {
                        firstPos = objects[i];
                        lastPos = objects[i + 1];
                        lookPos = LookTargetObjects[i + 1];
                    }
                    float distance = Vector3.Distance(firstPos.transform.position, lastPos.transform.position);
                    if (!isSeeMain)
                        transform.LookAt(lastPos.transform);
                    transform.DOMove(lastPos.transform.position, distance * AIManager.Instance.walkFactor).SetEase(easeType);
                    yield return new WaitForSeconds(distance * AIManager.Instance.walkFactor);
                    if (!isSeeMain)
                        transform.LookAt(lookPos.transform);
                    yield return new WaitForSeconds(4);
                }
        }

    }
}
