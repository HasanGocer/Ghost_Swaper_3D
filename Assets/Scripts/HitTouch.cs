using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTouch : MonoBehaviour
{
    public bool isRival;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival")&& isRival)
        {
            RivalID rivalID = other.GetComponent<RivalID>();
            ItemData.Field field = ItemData.Instance.field;

            rivalID.characterBar.BarUpdate(field.rivalHealth, rivalID.rivalHealth, field.mainDamage);
            rivalID.rivalHealth -= field.mainDamage;
        }
        if (other.CompareTag("Main")&& !isRival)
        {
            ItemData.Field field = ItemData.Instance.field;

            other.GetComponent<CharacterBar>().BarUpdate(field.mainHealth, GhostManager.Instance.mainHealth, field.rivalDamage);
            GhostManager.Instance.mainHealth -= field.rivalDamage;
        }
    }
}
