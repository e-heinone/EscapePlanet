using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Resources { Wood, Metal, Oil}
public class PlayerEntity : Entity
{
    private static int MetalAmount, WoodAmount;
    [SerializeField]
    private static int MetalMaxAmount = 10, WoodMaxAmount = 10;

    public static GameObject carriedObject;

    public static GameObject me;
    /// <summary>
    /// Returns false if not enough resources. Changes value only if true.
    /// </summary>
    /// <param name="resource">Enum which defines which resource you are using</param>
    /// <param name="amount">Amount of resource to spent</param>
    /// <returns></returns>
    /// 

    private void Awake()
    {
        me = gameObject;
    }
    public static bool SpentResource(Resources resource, int amount){
        if(resource == Resources.Wood)
        {
            if(WoodAmount - amount < 0)
            {
                return false;
            } else
            {
                WoodAmount -= amount;
                return true;
            }      
        } else if (resource == Resources.Metal)
        {
            if (MetalAmount - amount < 0)
            {
                return false;
            }
            else
            {
                MetalAmount -= amount;
                return true;
            }
        }
        else return false;
    }
    public static bool SpentResource(Dictionary<Resources, int> price)
    {
        price.TryGetValue(Resources.Wood, out int woodPrice);
        price.TryGetValue(Resources.Metal, out int metalPrice);
        if (WoodAmount - woodPrice < 0 || MetalAmount - metalPrice < 0)
        {
            return false;
        }
        else
        {
            WoodAmount -= woodPrice;
            MetalAmount -= metalPrice;
            return true;
        }
    }
    /// <summary>
    /// Returns false if exceeds max value. Changes value only if true.
    /// </summary>
    /// <param name="resource">Enum which defines which resource you are using</param>
    /// <param name="amount">Amount of resource to add</param>
    /// <returns></returns>
    public static bool AddResources(Resources resource, int amount)
    {
        if (resource == Resources.Wood)
        {
            if (WoodAmount + amount > WoodMaxAmount)
            {
                return false;
            }
            else
            {
                WoodAmount += amount;
                return true;
            }
        }
        else if (resource == Resources.Metal)
        {
            if (MetalAmount + amount > MetalMaxAmount)
            {
                return false;
            }
            else
            {
                MetalAmount += amount;
                return true;
            }
        }
        else return false;
    }

    public static bool PickObject(GameObject entity)
    {
        if(carriedObject == null)
        {
            carriedObject = entity;
            return true;
        }
        else
        {
            GameUI.gameUI.ReportToPlayer("You are already holding an item!");
            return false;
        }
    }
    public static int GetMetalAmount() { return MetalAmount; }

    public static int GetWoodAmount() { return WoodAmount; }

    public static string GetCarriedObjectName() { if (carriedObject != null) return carriedObject.name; else { return ""; }; }
}
