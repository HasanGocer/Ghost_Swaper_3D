using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival"))
        {
            RivalID rivalID = other.GetComponent<RivalID>();
            ItemData.Field field = ItemData.Instance.field;

            other.GetComponent<CharacterBar>().BarUpdate(field.rivalHealth, rivalID.rivalHealth, field.mainDamage);
            rivalID.rivalHealth -= field.mainDamage;
        }
        if (other.CompareTag("Main"))
        {
            ItemData.Field field = ItemData.Instance.field;

            other.GetComponent<CharacterBar>().BarUpdate(field.mainHealth, GhostManager.Instance.mainHealth, field.rivalDamage);
            GhostManager.Instance.mainHealth -= field.rivalDamage;
        }
    }
}
