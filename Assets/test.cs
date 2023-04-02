using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    public GameObject destiantiotN;
    // Start is called before the first frame update
    void Start()
    {
        destiantiotN = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(destiantiotN.transform.position);
    }
}
