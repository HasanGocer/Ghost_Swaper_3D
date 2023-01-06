using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;

public class HitTouchCharacter : MonoBehaviour
{
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
        main.GetComponent<AnimController>().CallDeadAnim();
        main.GetComponent<CapsuleCollider>().enabled = false;
        main.GetComponent<RivalSeeDistance>().isSwap = true;
        //partical
    }
    private IEnumerator CameraSwap(GameObject rival)
    {
        /*var motionBlur = GhostManager.Instance.postProcessVolume.profile.GetSetting<MotionBlur>();
        motionBlur.active = true;
        Time.timeScale = 0.5f;*/
        CamMoveControl.Instance.target = rival;
        yield return new WaitForSecondsRealtime(1);
        /* Time.timeScale = 1f;
         motionBlur.active = false;*/
    }
    private void CharacterSwap(GameObject rival)
    {
        GhostManager.Instance.mainPlayer.tag = "Dead";
        GhostManager.Instance.mainPlayer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = MaterialSystem.Instance.deadMaterial;
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
