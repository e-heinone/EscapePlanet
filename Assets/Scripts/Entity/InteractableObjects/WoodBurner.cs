using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBurner : Entity, IInteractable
{
    [SerializeField]
    public GameObject oil;

    public void Interaction()
    {
        if(PlayerEntity.SpentResource(Resources.Wood, 5)){
            Invoke(nameof(SpawnOil), 20f);
        } else
        {
            GameUI.gameUI.ReportToPlayer("You need wood to produce oil!");
        }
    }

    private void SpawnOil()
    {
        Instantiate(oil, gameObject.transform.position + new Vector3(Random.Range(-1,1),0, Random.Range(-1, 1)), Quaternion.identity) ;
    }
}
