using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class PrintedObject : MonoBehaviour, IInteractable
{
    private static GameObject reference;
    private static MeshFilter[] meshes;
    private static GameObject thisGameObject;
    private static GameObject testObject;
    public void Awake()
    {
        thisGameObject = gameObject;
        thisGameObject.SetActive(false);
    }
    public void Interaction()
    {
        if (PlayerEntity.PickObject(reference))
        {
            thisGameObject.SetActive(false);
            Destroy(testObject);
        }
    }

    public static void Print(GameObject obj)
    {
        //meshes = obj.transform.GetChild(0). GetComponentsInChildren<MeshFilter>();
        //CombineInstance[] combine = new CombineInstance[meshes.Length];
        //int i = 0;
        //while (i < meshes.Length)
        //{
        //    combine[i].mesh = meshes[i].sharedMesh;
        //    combine[i].transform = meshes[i].transform.localToWorldMatrix;
        //    meshes[i].gameObject.SetActive(false);

        //    i++;
        //}
        //thisGameObject.transform.GetComponent<MeshFilter>().mesh = new Mesh();
        //thisGameObject.transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        testObject = Instantiate(obj,thisGameObject.transform.position, Quaternion.identity);
        thisGameObject.SetActive(true);
        reference = obj;
    }
}
