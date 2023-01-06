using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTouch : MonoBehaviour
{
    [SerializeField] private RoomID roomID;

    private void TouchMain()
    {
        foreach(int i in GhostManager.Instance.room)
    }
}
