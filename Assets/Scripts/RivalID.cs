using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalID : MonoBehaviour
{
    public int rivalHealth;

    public void RivalIDStart()
    {
        ItemData.Instance.field.rivalHealth = rivalHealth;
    }
}
