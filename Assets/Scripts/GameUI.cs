using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameUI : MonoBehaviour
{
    public TMP_Text WoodText, MetalText, MessageText, YouAreHolding;
    public static GameUI gameUI;
    public GameObject AnvilMenu;

    public GameObject Tripod, CarryBin;

    public GameObject TurretCanvas, TurretAmmo, TurretName;

    public Button binButton;
    private void Awake()
    {
        gameUI = GetComponent<GameUI>();
        AnvilMenu.SetActive(false);
        binButton.interactable = false;
    }
    private void Update()
    { 
        WoodText.text = "Wood: " + PlayerEntity.GetWoodAmount().ToString();
        MetalText.text = "Metal: " + PlayerEntity.GetMetalAmount().ToString();

        YouAreHolding.text = "You are holding: " + PlayerEntity.GetCarriedObjectName();

        
    }

    public void ReportToPlayer(string text)
    {
        MessageText.text = text;
        Invoke(nameof(ResetMessage), 1.5f);
    }

    private void ResetMessage()
    {
        MessageText.text = "";
    }

    public void ExitAnvilMenu()
    {
        CameraAndMovementController.SwitchMenuState();
        GameUI.gameUI.AnvilMenu.SetActive(false);
    }

    public void PrintTripod()
    {
        if (PlayerEntity.SpentResource(SetupPrice(0, 10, 0)))
        {
            PrintedObject.Print(Tripod);
            binButton.interactable = true;
        }
        else
        {
            ReportToPlayer("You need more resources!");
        }
    }
    public void PrintCarryingBin()
    {
        if (PlayerEntity.SpentResource(SetupPrice(0, 10, 0)))
        {
            PrintedObject.Print(CarryBin);
        }
        else
        {
            ReportToPlayer("You need more resources!");
        }
    }

    public Dictionary<Resources,int> SetupPrice(int wood, int metal, int oil)
    {
        Dictionary<Resources, int> price = new Dictionary<Resources, int>();
        price.Add(Resources.Wood, wood);
        price.Add(Resources.Metal, metal);
        price.Add(Resources.Oil, oil);
        return price;
    }

    public void SetTurretInfo(Turret turret)
    {
        TurretAmmo.GetComponent<TMP_Text>().text = "Ammo " + turret.Ammo + "/" + turret.AmmoCapacity;
        TurretName.GetComponent<TMP_Text>().text = turret.name;
    }
}

