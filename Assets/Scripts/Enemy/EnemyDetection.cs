using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public EnemyController enemyController;

    private void OnTriggerEnter(Collider other)
    {
        int rnd = Random.Range(0, 100);

        if (rnd <= 80)
        {
            if (enemyController.PreferredTarget == PreferredTargetType.Player)
            {
                if (other.gameObject.tag == "Player")
                {
                    enemyController.targets.Add(other.gameObject);
                }
                return;
            }

            else if (enemyController.PreferredTarget == PreferredTargetType.Turret)
            {
                if (other.gameObject.tag == "Turret")
                {
                    enemyController.targets.Add(other.gameObject);
                }
                return;
            }

            else if (enemyController.PreferredTarget == PreferredTargetType.Base)
            {
                if (other.gameObject.tag == "Base")
                {
                    enemyController.targets.Add(other.gameObject);
                }
                return;
            }
        }

        else
            enemyController.targets.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        enemyController.targets.Remove(other.gameObject);
    }
}
