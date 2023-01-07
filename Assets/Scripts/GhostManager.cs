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
    public int mainHealth;

    public void StartGhostManager()
    {
        mainHealth = ItemData.Instance.field.mainHealth;
    }
}

