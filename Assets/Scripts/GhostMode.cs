using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GhostMode : MonoBehaviour
{

    //iptal
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival"))
        {
            RivalControl(other.gameObject);
            CameraSwap(other.gameObject);
            CharacterSelect(other.gameObject);
            ComponentPlacement();
            DeadCountAndFinishCheck();
        }
    }

    private void RivalControl(GameObject rival)
    {
        rival.GetComponent<RivalAI>().isLive = false;
    }
    private void CameraSwap(GameObject rival)
    {
        GhostManager.Instance.camera.transform.DOMove(rival.GetComponent<RivalID>().cameraTempPos.transform.position, 2).SetEase(Ease.InOutBack);
        //targert deðiþim
    }
    private void CharacterSelect(GameObject rival)
    {
        GhostManager.Instance.mainPlayer = rival;
        rival.tag = "Main";
    }
    private void ComponentPlacement()
    {
        GameObject main = GhostManager.Instance.mainPlayer;
        main.GetComponent<MainSeeDistance>().enabled = false;
        main.AddComponent<RivalSeeDistance>();
    }
    private void DeadCountAndFinishCheck()
    {
        FinishSystem.Instance.deadRival++;
        FinishSystem.Instance.FinishCheck();
    }
}
