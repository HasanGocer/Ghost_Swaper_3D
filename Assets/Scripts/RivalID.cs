using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalID : MonoBehaviour
{
    public int rivalHealth;
    public CharacterBar characterBar;
    public RivalAI rivalAI;
    public MainSeeDistance mainSeeDistance;
    public Hit hit;
    public AnimController animController;
    public LookCamera lookCamera;
    public RoomID roomID;

    public void RivalIDStart()
    {
        rivalHealth = ItemData.Instance.field.rivalHealth;
    }
}
