using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PolttouuniAnimation : MonoBehaviour
{
    //Bool to connect to the actual script
    [SerializeField]
    public bool working;
    //Chimney 
    private GameObject chimney;
    [SerializeField]
    private float chimneyMovement;
    [SerializeField]
    private float chimneyMovementSpeed;
    private Vector3 chimneyScale;
    private bool scalingUp;
    private float chimneyMaxScale, chimneyMinScale;

    //Door
    private GameObject door;
    [SerializeField]
    private float rotationSpeed = 45f;

    private Quaternion startRotation;
    private Quaternion endRotation;
    private float rotateAngle;


    Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        //chimney
        chimney = transform.GetChild(2).gameObject;
        chimneyMaxScale = chimney.transform.localScale.z + chimneyMovement;
        chimneyMinScale = chimney.transform.localScale.z - chimneyMovement;
        //Door
        door = transform.GetChild(1).gameObject;
        startRotation = door.transform.rotation;
        endRotation = new Quaternion(-0.69555f, -0.12732f, -0.12732f, 0.69555f);
        rotateAngle = Quaternion.Angle(startRotation, endRotation);
    }

    // Update is called once per frame
    void Update()
    {
        chimneyScale = chimney.transform.localScale;
        if (working)
        {
            //Chimney
            if (chimneyScale.z > chimneyMaxScale)
                scalingUp = false;
            else if (chimneyScale.z < chimneyMinScale)
                scalingUp = true;
            if (scalingUp)
                chimney.transform.localScale = chimney.transform.localScale + new Vector3(0, 0, chimneyMovementSpeed);

            else if (!scalingUp)
                chimney.transform.localScale = chimney.transform.localScale + new Vector3(0, 0, -chimneyMovementSpeed);


            // Rotate, close
            //if ((Quaternion.Angle(door.transform.rotation, startRotation) > 0))
            //{
            //    Quaternion rot = Quaternion.Euler(0, rotationSpeed * Time.time, 0);
            //    door.transform.rotation = rot * endRotation;

            //}
        }
        if (!working)
        {
            // Rotate, open
        //    if ((Quaternion.Angle(door.transform.rotation, endRotation) > 0))
        //    {
        //        Quaternion rot = Quaternion.Euler(0, -rotationSpeed * Time.time, 0);
        //        door.transform.rotation = rot * endRotation;

        //    }
        }
        //// Debug.Log("curAngO: " + Quaternion.Angle(door.transform.rotation, endRotation));

        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    Debug.Log("CurQuar: " + door.transform.rotation);
        //    Debug.Log("GoalAng: " + rotateAngle);
        //    Debug.Log("curAngO: " + Quaternion.Angle(door.transform.rotation, endRotation));
        //    Debug.Log("curAngC: " + Quaternion.Angle(door.transform.rotation, startRotation));

        //}
    }
}
