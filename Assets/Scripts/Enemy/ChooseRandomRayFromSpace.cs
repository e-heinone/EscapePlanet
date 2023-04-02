using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomRayFromSpace : MonoBehaviour
{
    public Vector3 targetLocation;
    private RaycastHit hit;
    private float distance = 300f;

    private int offsetXpoint;
    private int offsetZpoint;

    public void ShootRay()
    {
        offsetXpoint = Random.Range(-375, 375);
        offsetZpoint = Random.Range(-375, 375);

        //Debug.DrawRay(new Vector3(transform.position.x + offsetXpoint, transform.position.y, transform.position.z + offsetZpoint), Vector3.down * 300, Color.red, Mathf.Infinity);

        if (Physics.Raycast(new Vector3(transform.position.x + offsetXpoint, transform.position.y, transform.position.z + offsetZpoint), Vector3.down, out hit, distance * 300))
        {
            // layer 6 = "Ground"
            if (hit.transform.gameObject.layer == 6)
            {
                targetLocation = hit.point;
                Debug.Log("Hit point is: " + targetLocation);
            }
        }
    }
}
