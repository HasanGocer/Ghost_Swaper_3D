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
            RivalControl(other.gameObject);
            BacksRivalDead();
            CameraSwap(other.gameObject);
            CharacterSwap(other.gameObject);
            ComponentPlacement();
            DeadCountAndFinishCheck();
        }
        else if (other.CompareTag("Main"))
        {
            //fail
        }
    }

    private void RivalControl(GameObject rival)
    {
        rival.GetComponent<RivalAI>().isLive = false;
        rival.GetComponent<PlayerMovment>().enabled = false;
    }
    private void BacksRivalDead()
    {
        GameObject main = GhostManager.Instance.mainPlayer;
        main.GetComponent<AnimController>().CallDeadAnim();
        main.GetComponent<CapsuleCollider>().enabled = false;
        main.GetComponent<RivalSeeDistance>().isSwap = true;
        //partical
    }
    private void CameraSwap(GameObject rival)
    {
        CamMoveControl.Instance.target = rival;
    }
    private void CharacterSwap(GameObject rival)
    {
        GhostManager.Instance.mainPlayer.tag = "Rival";
        GhostManager.Instance.mainPlayer = rival;
        rival.tag = "Main";
    }
    private void ComponentPlacement()
    {
        GameObject main = GhostManager.Instance.mainPlayer;
        main.GetComponent<MainSeeDistance>().enabled = false;
        main.AddComponent<RivalSeeDistance>();
        PlayerMovment playerMovment = main.AddComponent<PlayerMovment>();
        playerMovment.joystick = GhostManager.Instance.joystick;
        playerMovment.rb = main.GetComponent<Rigidbody>();
    }
    private void DeadCountAndFinishCheck()
    {
        FinishSystem.Instance.deadRival++;
        FinishSystem.Instance.FinishCheck();
    }
}
