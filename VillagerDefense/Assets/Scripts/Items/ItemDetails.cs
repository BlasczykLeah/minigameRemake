using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDetails : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject player;   // this will be set when the item enters this player's inventory

    public bool isWeapon;
    public string itemName;
    public string description;
    public GameObject myWeapon;
    public Attack weaponScript;

    public Text nameTxt;    //maybe sell price?
    public Text descTxt;

    // hover text desc and otehr fun jazz
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowDetails();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideDetails();
    }


    public void ShowDetails()
    {
        nameTxt.text = itemName;

        string newText = description.Replace("@", System.Environment.NewLine);
        descTxt.text = newText;
    }

    public void HideDetails()
    {
        nameTxt.text = descTxt.text = "";
    }
}
