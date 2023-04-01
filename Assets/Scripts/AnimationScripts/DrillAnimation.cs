using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrillAnimation : MonoBehaviour
{
    //Hoverbox
    private GameObject hoverBox;
    [SerializeField]
    private float heightDifferential;
    private Vector3 hoverBoxPos;
    private bool goingDown;
    private float maxHoverHeight;
    private float minHoverHeight;
    [SerializeField]
    private float hoverSpeed;

    //Drill
    private GameObject drill;
    [SerializeField]
    private float drillDepth;
    [SerializeField]
    private float drillMoveSpeed;
    [SerializeField]
    private float drillRotationSpeed;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        //HoverBox
        hoverBox = gameObject.transform.GetChild(1).gameObject;
        maxHoverHeight = hoverBox.transform.position.y + heightDifferential;
        minHoverHeight = hoverBox.transform.position.y - heightDifferential;

        //Drill
        drill = gameObject.transform.GetChild(2).gameObject;
        startRotation = drill.transform.rotation;
        //Put Drill to position 0.2
        Vector3 newDrillPos = new Vector3(drill.transform.position.x, drill.transform.position.y - drillDepth, drill.transform.position.z);
        drillDepth = drill.transform.position.y - drillDepth;
        StartCoroutine(MoveDrill());
    }

    // Update is called once per frame
    void Update()
    {
        // HoverBox
        hoverBoxPos = hoverBox.transform.position;
        if (hoverBoxPos.y > maxHoverHeight)
            goingDown = true;
        else if (hoverBoxPos.y < minHoverHeight)
            goingDown = false;
        if (goingDown)
            hoverBox.transform.position = hoverBox.transform.position + new Vector3(0, -hoverSpeed, 0);

        else if (!goingDown)
            hoverBox.transform.position = hoverBox.transform.position + new Vector3(0, hoverSpeed, 0);

        //Drill
        Quaternion rot = Quaternion.Euler(0, drillRotationSpeed * Time.time, 0);
        drill.transform.rotation = rot * startRotation;
    }

    IEnumerator MoveDrill()
    {
        while (drill.transform.position.y >= drillDepth)
        {
            drill.transform.position = drill.transform.position + new Vector3(0, -drillMoveSpeed, 0);
            yield return null;
        }

    }
}
