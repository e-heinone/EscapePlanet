using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodResource : MonoBehaviour, IInteractable
{
    public void Interaction()
    {
        if(!PlayerEntity.AddResources(Resources.Wood, 1))
        {
            GameUI.gameUI.ReportToPlayer("You reached max wood capacity!");
            
        } else
        {
            Destroy(gameObject);
        }
    }
}
