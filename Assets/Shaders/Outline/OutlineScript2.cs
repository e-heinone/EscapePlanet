using UnityEngine;

public class OutlineScript2 : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    private Material outlineMaterial;

    private Material[] tempMaterials;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        tempMaterials = _meshRenderer.materials;
        tempMaterials[0] = defaultMaterial;
        tempMaterials[1] = defaultMaterial;
        ApplyMaterialChanges();
    }

    // Call function when raycast hits interactable object at required range
    public void InInteractRange()
    {
        tempMaterials[0] = defaultMaterial;
        tempMaterials[1] = outlineMaterial;
        ApplyMaterialChanges();
    }

    // Call function when raycast leaves interactable object or its range
    public void OutOfInteractRange()
    {
        tempMaterials[0] = defaultMaterial;
        tempMaterials[1] = defaultMaterial;
        ApplyMaterialChanges();
    }

    void ApplyMaterialChanges()
    {
        _meshRenderer.materials = tempMaterials;
    }

    // FOR TESTING PURPOSES, REMOVE LATER WHEN EVERYTHING WORKS!!!!
    //void OnMouseOver()
    //{
    //    tempMaterials[0] = defaultMaterial;
    //    tempMaterials[1] = outlineMaterial;
    //    ApplyMaterialChanges();
    //}
    //void OnMouseExit()
    //{
    //    tempMaterials[0] = defaultMaterial;
    //    tempMaterials[1] = defaultMaterial;
    //    ApplyMaterialChanges();
    //}
}
