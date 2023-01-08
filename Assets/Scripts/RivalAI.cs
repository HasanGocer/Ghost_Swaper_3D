using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RivalAI : MonoBehaviour
{
    public bool isLive = true, isSeeMain, isIssuse;
    [SerializeField] private Ease easeType = Ease.InOutSine;
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private List<GameObject> LookTargetObjects;
    [SerializeField] private RivalID rivalID;

    public void StartAI()
    {
        StartCoroutine(RunPath(objects, LookTargetObjects));
    }

    private IEnumerator RunPath(List<GameObject> objects, List<GameObject> LookTargetObjects)
    {
        GameObject firstPos, lastPos, lookPos;
        while (isLive)
        {
            yield return null;
            if (!isSeeMain && rivalID.roomID.RoomActive && !isIssuse)
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
                    if (!isSeeMain && !isIssuse)
                    {
                        transform.LookAt(lastPos.transform);
                        transform.DOMove(lastPos.transform.position, distance * AIManager.Instance.walkFactor).SetEase(easeType);
                        rivalID.animController.CallWalkAnim();
                    }
                    yield return new WaitForSeconds(distance * AIManager.Instance.walkFactor);
                    if (!isSeeMain && !isIssuse)
                    {
                        transform.LookAt(lookPos.transform);
                        rivalID.animController.CallIdleAnim();
                    }
                    yield return new WaitForSeconds(4);
                }
        }

    }
}
