using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripod : Turret, ITurret
{
    public GameObject pistol, sailio, bullet;
    public GameObject bulletthis;
    public GameObject RangeObject;
    public void Start()
    {
        InvokeRepeating("SingleShot", 0.3f, 0.3f);
    }
    public void Shoot()
    {

    }

    public void Burst()
    {

    }

    public void SingleShot()
    {
        if (targets.Count > 0 && Ammo > 0)
        {


            Ammo--;
            bulletthis = Instantiate(bullet, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            bulletthis.transform.LookAt(targets[0].transform);
            bulletthis.GetComponent<Rigidbody>().AddForce((targets[0].transform.position - bulletthis.transform.position) * 800);

            Invoke(nameof(DestroyBullet), 5f);
        }

    }

    private void Update()
    {
        if (targets.Count > 0)
        {
            pistol.transform.LookAt(targets[0].transform);
            sailio.transform.LookAt(targets[0].transform);
        }

    }

    private void DestroyBullet()
    {
        Destroy(bulletthis);
    }
}
