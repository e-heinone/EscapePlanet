using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintedObject : MonoBehaviour, IInteractable
{
    private static GameObject reference;
    private static MeshFilter meshf;
    private static GameObject thisGameObject;
    public void Awake()
    {
        thisGameObject = gameObject;
        meshf = GetComponent<MeshFilter>();
        thisGameObject.SetActive(false);
    }
    public void Interaction()
    {
        if (PlayerEntity.PickObject(reference))
        {
            thisGameObject.SetActive(false);
        }
    }

    public static void Print(GameObject obj)
    {
        thisGameObject.SetActive(true);
        meshf.mesh = obj.GetComponent<MeshFilter>().mesh;
        reference = obj;
    }
}
