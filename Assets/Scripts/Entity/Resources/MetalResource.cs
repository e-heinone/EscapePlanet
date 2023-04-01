using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalResource : MonoBehaviour,  IInteractable
{
    public void Interaction()
    {
        if (!PlayerEntity.AddResources(Resources.Metal, 1))
        {
            GameUI.gameUI.ReportToPlayer("You reached max metal capacity!");

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
