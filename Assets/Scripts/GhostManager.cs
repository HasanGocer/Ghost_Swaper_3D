using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GhostManager : MonoSingleton<GhostManager>
{
    public RoomID StayRoom;
    public GameObject mainPlayer;
    public AnimController animController;
    public Joystick joystick;
    public VolumeProfile volume;

    public void StartGhostManager()
    {
        StartCoroutine(mainPlayer.GetComponent<RivalSeeDistance>().MainSeeRaycast());
        animController.CallIdleAnim();
    }
}

