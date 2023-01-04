using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HitTouchCharacter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival"))
        {

        }
        else if (other.CompareTag("Main"))
        {
            //fail
        }
    }

    private void RivalControl(GameObject rival)
    {
        rival.GetComponent<RivalAI>().isLive = false;
    }

    private void BacksRivalDead()
    {
        GameObject main = GhostManager.Instance.mainPlayer;
        main.GetComponent<AnimController>().CallDeadAnim();
        main.GetComponent<CapsuleCollider>().enabled = false;
        //partical
    }
    private void CameraSwap(GameObject rival)
    {
        GhostManager.Instance.camera.transform.DOMove(rival.GetComponent<RivalID>().cameraTempPos.transform.position, 2).SetEase(Ease.InOutBack);
        //targert deðiþim
    }
    private void ComponentPlacement()
    {
        GameObject main = GhostManager.Instance.mainPlayer;
        main.GetComponent<MainSeeDistance>().enabled = false;
        main.AddComponent<RivalSeeDistance>();
    }
    private void CharacterSwap(GameObject rival)
    {
        GhostManager.Instance.mainPlayer.tag = "Rival";
        GhostManager.Instance.mainPlayer = rival;
        rival.tag = "Main";
    }
    private void DeadCountAndFinishCheck()
    {
        FinishSystem.Instance.deadRival++;
        FinishSystem.Instance.FinishCheck();
    }
}
