using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostMode : MonoSingleton<GhostMode>
{
    [SerializeField] private GameObject ghost;
    [SerializeField] private Button ghostModeButton;

    public void GhostModeStart()
    {
        ghostModeButton.onClick.AddListener(GhostDistance);
    }

    private void GhostDistance()
    {
        GameObject tempRival = ghost;
        float tempDistance = 10000;

        for (int i = 0; i < FinishSystem.Instance.focusScene.Rivals.Count; i++)
        {
            if (tempDistance > Vector3.Distance(FinishSystem.Instance.focusScene.Rivals[i].transform.position, ghost.transform.position))
            {
                tempDistance = Vector3.Distance(FinishSystem.Instance.focusScene.Rivals[i].transform.position, ghost.transform.position);
                tempRival = FinishSystem.Instance.focusScene.Rivals[i];
            }
        }
        RivalID rivalID = tempRival.GetComponent<RivalID>();

        Buttons.Instance._startPanel.SetActive(false);
        GameManager.Instance.isStart = true;
        RivalControl(rivalID);
        StartCoroutine(CameraSwap(tempRival));
        CharacterSwap(tempRival);
        ComponentPlacement(rivalID);
        TouchMain(rivalID);
        DeadCountAndFinishCheck();
    }

    private void RivalControl(RivalID rivalID)
    {
        rivalID.rivalAI.isLive = false;
    }
    private IEnumerator CameraSwap(GameObject rival)
    {
        GhostManager.Instance.volume.components[3].active = true;
        Time.timeScale = 0.4f;
        CamMoveControl.Instance.target = rival;
        yield return new WaitForSecondsRealtime(2);
        GhostManager.Instance.volume.components[3].active = false;
        Time.timeScale = 1f;
    }
    private void CharacterSwap(GameObject rival)
    {
        GhostManager.Instance.mainPlayer = rival;
        rival.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = MaterialSystem.Instance.MainMaterial;
        rival.tag = "Main";
    }
    private void ComponentPlacement(RivalID rivalID)
    {
        GameObject main = GhostManager.Instance.mainPlayer;


        RivalSeeDistance rivalSeeDistance = main.AddComponent<RivalSeeDistance>();
        PlayerMovment playerMovment = main.AddComponent<PlayerMovment>();

        rivalID.roomID.RoomActive = true;
        GhostManager.Instance.animController = rivalID.animController;
        rivalSeeDistance.hit = rivalID.hit;
        playerMovment.joystick = GhostManager.Instance.joystick;
        playerMovment.rb = main.GetComponent<Rigidbody>();
        StartCoroutine(rivalSeeDistance.MainSeeRaycast());
    }
    private void TouchMain(RivalID rivalID)
    {
        rivalID.roomID.RoomActive = true;
        foreach (int i in rivalID.roomID.FriendRoom)
        {
            FinishSystem.Instance.focusScene.Rooms[i - 1].GetComponent<RoomID>().RoomActive = true;
        }
    }
    private void DeadCountAndFinishCheck()
    {
        FinishSystem.Instance.deadRival++;
        FinishSystem.Instance.FinishCheck();
    }
}
