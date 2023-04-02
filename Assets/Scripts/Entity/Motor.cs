using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : Entity, IInteractable
{
    private bool producingEnergy = false;
    public void Interaction()
    {
        if(PlayerEntity.carriedObject != null)
        {
            if(PlayerEntity.carriedObject.GetComponent<Oil>() != null && producingEnergy == false)
            {
                PlayerEntity.GlobalEnergy++;
                producingEnergy = true;
                Invoke(nameof(Deplete), 180f);

                PlayerEntity.carriedObject = null;
            }
            else if (producingEnergy == false)
            {
                GameUI.gameUI.ReportToPlayer("You need oil to produce energy!");
            }
        }

        else if (producingEnergy == false)
        {
            GameUI.gameUI.ReportToPlayer("You need oil to produce energy!");
        }
    }

    private void Deplete()
    {
        producingEnergy = false;
        PlayerEntity.GlobalEnergy--;
    }
}
