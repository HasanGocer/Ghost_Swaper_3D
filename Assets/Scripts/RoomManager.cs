using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoSingleton<RoomManager>
{
    [System.Serializable]
    public class RoomScens
    {
        public List<GameObject> Rivals = new List<GameObject>();
        public List<GameObject> Rooms = new List<GameObject>();
        public int rivalCount;
        public GameObject ScenePanel;
    }
    public List<RoomScens> roomScens = new List<RoomScens>();

    public void RivalCountPlacement()
    {
        RoomScens tempRoomScens = roomScens[GameManager.Instance.level];
        tempRoomScens.ScenePanel.SetActive(true);
        FinishSystem.Instance.focusScene = tempRoomScens;

        for (int i = 0; i < tempRoomScens.Rooms.Count; i++)
        {
            RoomID roomID = tempRoomScens.Rooms[i].GetComponent<RoomID>();

            tempRoomScens.rivalCount += roomID.Rivals.Count;
            RivalsStart(roomID);
        }
    }

    private void RivalsStart(RoomID roomID)
    {
        for (int i1 = 0; i1 < roomID.Rivals.Count; i1++)
        {
            RivalAI rivalAI = roomID.Rivals[i1].GetComponent<RivalAI>();
            RivalID rivalID = roomID.Rivals[i1].GetComponent<RivalID>();
            MainSeeDistance mainSeeDistance = roomID.Rivals[i1].GetComponent<MainSeeDistance>();

            rivalID.RivalIDStart();
            StartCoroutine(mainSeeDistance.MainSeeRaycast());
            rivalAI.StartAI();
        }
    }
}
