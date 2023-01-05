using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoSingleton<GhostManager>
{
    public GameObject mainPlayer;
    public Joystick joystick; // The instantiated joystick object
}
