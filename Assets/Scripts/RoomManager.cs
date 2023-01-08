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

        roomScens[GameManager.Instance.level].ScenePanel.SetActive(true);
        FinishSystem.Instance.focusScene = roomScens[GameManager.Instance.level];

        for (int i = 0; i < roomScens[GameManager.Instance.level].Rooms.Count; i++)
        {
            RoomID roomID = roomScens[GameManager.Instance.level].Rooms[i].GetComponent<RoomID>();

            roomScens[GameManager.Instance.level].rivalCount += roomID.Rivals.Count;
            RivalsStart(roomID);
        }
    }

    private void RivalsStart(RoomID roomID)
    {
        for (int i1 = 0; i1 < roomID.Rivals.Count; i1++)
        {
            RivalID rivalID = roomID.Rivals[i1].GetComponent<RivalID>();

            StartCoroutine(rivalID.lookCamera.LookFocusCamera());
            rivalID.RivalIDStart();
            StartCoroutine(rivalID.mainSeeDistance.MainSeeRaycast(rivalID));
            rivalID.rivalAI.StartAI();
        }
    }
}
