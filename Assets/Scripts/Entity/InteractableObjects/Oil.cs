using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : Entity, IInteractable
{
    public void Interaction()
    {
        if (PlayerEntity.carriedObject == null)
        {
            PlayerEntity.carriedObject = Instantiate(gameObject, new Vector3(-1100000, 1000000, -1000000), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
