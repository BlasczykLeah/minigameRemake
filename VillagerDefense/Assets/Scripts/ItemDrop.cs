using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler
{
    public bool hotBar;
    public int hotbarIndex;

    public Inventory inventory;
    public GameObject myItem;

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        RectTransform mySpace = transform as RectTransform;
        if(RectTransformUtility.RectangleContainsScreenPoint(mySpace, Input.mousePosition))
        {
            Debug.Log("Place Object at " + gameObject.name);

            PlaceItem();
        }
    }

    void PlaceItem()
    {
        if (myItem == null)
        {
            // set myItem to active item, set parent, set transform
            myItem = inventory.itemHeld;
            myItem.GetComponent<ItemDrag>().UpdateParent(this);
            myItem.transform.SetParent(transform);

            if (hotBar)
            {
                myItem.GetComponent<ItemDetails>().player.GetComponent<ActiveWeapon>().AddWeaponHotbar(hotbarIndex, myItem.GetComponent<ItemDetails>().myWeapon, myItem.GetComponent<ItemDetails>().weaponScript);
            }
        }
    }
}
