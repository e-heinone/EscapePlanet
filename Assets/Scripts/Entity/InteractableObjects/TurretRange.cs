using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRange : MonoBehaviour
{
    public Turret turret;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            turret.targets.Add(other.gameObject);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        turret.targets.Remove(other.gameObject);
    }
}
