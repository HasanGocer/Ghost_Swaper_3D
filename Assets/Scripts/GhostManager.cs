using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GhostManager : MonoSingleton<GhostManager>
{
    public RoomID StayRoom;
    public GameObject mainPlayer;
    public Joystick joystick; // The instantiated joystick object
    public PostProcessVolume postProcessVolume;
}

