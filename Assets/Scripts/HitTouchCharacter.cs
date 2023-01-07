using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;

public class HitTouchCharacter : MonoBehaviour
{
    //ÝPTAL AHMET ABÝYE KÜFÜRLER(Þaka ehe)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival"))
        {
            RivalControl(other.gameObject);
            BacksRivalDead();
            StartCoroutine(CameraSwap(other.gameObject));
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
        GhostManager.Instance.mainPlayer.GetComponent<PlayerMovment>().enabled = false;
    }
    private void BacksRivalDead()
    {
        GameObject main = GhostManager.Instance.mainPlayer;
        GhostManager.Instance.animController.CallDeadAnim();
        main.GetComponent<CapsuleCollider>().enabled = false;
        main.GetComponent<RivalSeeDistance>().isSwap = true;
        //partical
    }
    private IEnumerator CameraSwap(GameObject rival)
    {
        GhostManager.Instance.volume.components[3].active = true;
        Time.timeScale = 0.2f;
        CamMoveControl.Instance.target = rival;
        yield return new WaitForSecondsRealtime(2);
        GhostManager.Instance.volume.components[3].active = false;
        Time.timeScale = 1f;
    }
    private void CharacterSwap(GameObject rival)
    {
        GhostManager.Instance.mainPlayer.tag = "Dead";
        GhostManager.Instance.mainPlayer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = Color.Lerp(GhostManager.Instance.mainPlayer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color, MaterialSystem.Instance.deadMaterial.color, 1f);
        GhostManager.Instance.mainPlayer = rival;
        rival.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = MaterialSystem.Instance.MainMaterial;
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
