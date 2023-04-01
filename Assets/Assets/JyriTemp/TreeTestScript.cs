using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTestScript : MonoBehaviour
{
    int i;
    // Start is called before the first frame update
    void Awake()
    {
        i++;
        Debug.Log("TreeAwake");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Debug.Log(i);
    }
}
