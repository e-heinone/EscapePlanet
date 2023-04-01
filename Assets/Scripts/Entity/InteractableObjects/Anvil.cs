using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : Entity, IInteractable
{
    public void Interaction()
    {
        GameUI.gameUI.AnvilMenu.SetActive(true);

        CameraAndMovementController.SwitchMenuState();
    }
}
