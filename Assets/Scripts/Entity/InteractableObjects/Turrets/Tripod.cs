using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripod : Turret, ITurret
{
    public GameObject pistol, sailio;
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

    private void Update()
    {
        pistol.transform.LookAt(GameObject.Find("Player").transform);
       sailio.transform.LookAt(GameObject.Find("Player").transform);
    }
}
