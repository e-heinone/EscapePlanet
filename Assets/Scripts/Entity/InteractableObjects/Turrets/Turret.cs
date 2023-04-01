using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurret
{
    public void Shoot()
    {

    }
}



public class Turret : Entity
{

    public int Ammo, AmmoCapacity;
    public Resources resource;
    public int ResourceCapacity;

    private GameObject target;
    public void AddAmmo()
    {
        if (Ammo < AmmoCapacity)
        {
            if (PlayerEntity.SpentResource(resource, 1))
            {


                Ammo += (int)(AmmoCapacity / ResourceCapacity);
                if (Ammo > AmmoCapacity)
                {
                    Ammo = AmmoCapacity;
                }

            }
            else
            {
                GameUI.gameUI.ReportToPlayer("You need "+resource.ToString().ToLower()+" to refill this turret!");
            }
        }
        else
        {
            GameUI.gameUI.ReportToPlayer("Ammo is full!");
        }
    }
}

