using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoSingleton<ItemData>
{
    //managerde bulunacak

    [System.Serializable]
    public class Field
    {
        public int rivalHealth, mainHealth, mainDistance, rivalDistance, rivalDamage, mainDamage;
        public float mainDamageSpeed;
    }

    public Field field;
    public Field standart;
    public Field factor;
    public Field constant;
    public Field maxFactor;
    public Field max;
    public Field fieldPrice;

    private void Start()
    {

        field.rivalHealth = standart.rivalHealth + (factor.rivalHealth * constant.rivalHealth);
        field.mainHealth = standart.mainHealth + (factor.mainHealth * constant.mainHealth);
        fieldPrice.mainHealth = fieldPrice.mainHealth * factor.mainHealth;
        field.rivalDamage = standart.rivalDamage + (factor.rivalDamage * constant.rivalDamage);
        field.mainDamage = standart.mainDamage + (factor.mainDamage * constant.mainDamage);
        fieldPrice.mainDamage = fieldPrice.mainDamage * factor.mainDamage;
        field.mainHealth = standart.mainHealth + (factor.mainHealth * constant.mainHealth);
        fieldPrice.mainHealth = fieldPrice.mainHealth * factor.mainHealth;
        field.mainDistance = standart.mainDistance + (factor.mainDistance * constant.mainDistance);
        fieldPrice.mainDistance = fieldPrice.mainDistance * factor.mainDistance;
        field.rivalDistance = standart.rivalDistance + (factor.rivalDistance * constant.rivalDistance);
        field.mainDamageSpeed = standart.mainDamageSpeed + (factor.mainDamageSpeed * constant.mainDamageSpeed);
        fieldPrice.mainDamageSpeed = fieldPrice.mainDamageSpeed * factor.mainDamageSpeed;

        if (factor.rivalHealth > maxFactor.rivalHealth)
            field.rivalHealth = maxFactor.rivalHealth;
        if (factor.mainHealth > maxFactor.mainHealth)
            field.mainHealth = maxFactor.mainHealth;
        if (factor.mainDistance > maxFactor.mainDistance)
            field.mainDistance = max.mainDistance;
        if (factor.rivalDistance > maxFactor.rivalDistance)
            field.rivalDistance = max.rivalDistance;
        if (factor.rivalDamage > maxFactor.rivalDamage)
            field.rivalDamage = max.rivalDamage;
        if (factor.mainDamage > maxFactor.mainDamage)
            field.mainDamage = max.mainDamage;
        if (factor.mainDamageSpeed > maxFactor.mainDamageSpeed)
            field.mainDamageSpeed = max.mainDamageSpeed;


        RoomManager.Instance.RivalCountPlacement();
        GhostMode.Instance.GhostModeStart();
    }

    public void SetRivalHealth()
    {
        field.rivalHealth++;
        field.rivalHealth = standart.rivalHealth + (factor.rivalHealth * constant.rivalHealth);
        fieldPrice.rivalHealth = fieldPrice.rivalHealth * factor.rivalHealth;
        if (field.rivalHealth > max.rivalHealth)
            field.rivalHealth = max.rivalHealth;
    }

    public void SetMainHealth()
    {
        field.mainHealth++;
        field.mainHealth = standart.mainHealth + (factor.mainHealth * constant.mainHealth);
        fieldPrice.mainHealth = fieldPrice.mainHealth * factor.mainHealth;
        if (field.mainHealth > max.mainHealth)
            field.mainHealth = max.mainHealth;
    }

    public void SetMainDistance()
    {
        field.mainDistance++;
        field.mainDistance = standart.mainDistance + (factor.mainDistance * constant.mainDistance);
        fieldPrice.mainDistance = fieldPrice.mainDistance * factor.mainDistance;
        if (field.mainDistance > max.mainDistance)
            field.mainDistance = max.mainDistance;
    }

    public void SetRivalDistance()
    {
        field.rivalDistance++;
        field.rivalDistance = standart.rivalDistance + (factor.rivalDistance * constant.rivalDistance);
        fieldPrice.rivalDistance = fieldPrice.rivalDistance * factor.rivalDistance;
        if (field.rivalDistance > max.rivalDistance)
            field.rivalDistance = max.rivalDistance;
    }

    public void SetRivalDamage()
    {
        field.rivalDamage++;
        field.rivalDamage = standart.rivalDamage + (factor.rivalDamage * constant.rivalDamage);
        fieldPrice.rivalDamage = fieldPrice.rivalDamage * factor.rivalDamage;
        if (field.rivalDamage > max.rivalDamage)
            field.rivalDamage = max.rivalDamage;
    }

    public void SetMainDamage()
    {
        field.mainDamage++;
        field.mainDamage = standart.mainDamage + (factor.mainDamage * constant.mainDamage);
        fieldPrice.mainDamage = fieldPrice.mainDamage * factor.mainDamage;
        if (field.mainDamage > max.mainDamage)
            field.mainDamage = max.mainDamage;
    }

    public void SetMainDamageSpeed()
    {
        field.mainDamageSpeed++;
        field.mainDamageSpeed = standart.mainDamageSpeed + (factor.mainDamageSpeed * constant.mainDamageSpeed);
        fieldPrice.mainDamageSpeed = fieldPrice.mainDamageSpeed * factor.mainDamageSpeed;
        if (field.mainDamageSpeed > max.mainDamageSpeed)
            field.mainDamageSpeed = max.mainDamageSpeed;
    }
}
