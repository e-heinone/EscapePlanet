using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UfoRotateHover : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed = 45f;

    private Quaternion startRotation;

    private Transform startTransform;
    Vector3 currentPos;

    [SerializeField]
    private float heightDifferential;

    private float maxHeight;
    private float minHeight;
    private bool goingDown;


    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
        startTransform = transform;
        maxHeight = transform.position.y + heightDifferential;
        minHeight = transform.position.y - heightDifferential;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;

        // Rotate
        Quaternion rot = Quaternion.Euler(0, rotationSpeed * Time.time, 0);
        transform.rotation = rot * startRotation;


        // Hover in place
        if (currentPos.y > maxHeight)
            goingDown = true;
        else if (currentPos.y < minHeight)
            goingDown = false;
        if (goingDown)
            transform.position = transform.position + new Vector3(0, -0.001f, 0);

        else if (!goingDown)
            transform.position = transform.position + new Vector3(0, 0.001f, 0);
    }
}
