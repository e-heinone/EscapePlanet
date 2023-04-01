using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable 
{
    public void Interaction();
}
public class InteractableObject : Entity, IInteractable
{
    public void Interaction()
    {

    }
}
