using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripod : Turret, ITurret
{
    public void Shoot()
    {

    }

    public void Burst()
    {

    }

    public void SingleShot()
    {
        Ammo--;
        
    }
}
