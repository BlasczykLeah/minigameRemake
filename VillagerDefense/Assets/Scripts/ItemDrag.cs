using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Inventory inventory;
    public ItemDrop myParent;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (myParent != null)
        {
            if(myParent.GetComponent<ItemDrop>().hotBar) transform.SetParent(transform.parent.parent.parent);
            else transform.SetParent(transform.parent.parent);
            transform.SetSiblingIndex(0);
        }
        //GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        inventory.itemHeld = gameObject;        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // find box that it is hovered over, check if filled, if not snap change parent, else snap back
        // check from hotbar or to hotbar
        //GetComponent<CanvasGroup>().blocksRaycasts = true;
        Invoke("ResetPosition", 0.05F);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateParent(ItemDrop newParent)
    {
        if (myParent != null)
        {
            if (myParent.hotBar) GetComponent<ItemDetails>().player.GetComponent<ActiveWeapon>().RemoveWeaponHotbar(myParent.hotbarIndex);

            myParent.myItem = null;
        }
        myParent = newParent;
    }

    void ResetPosition()
    {
        if (!transform.parent.GetComponent<ItemDrop>()) transform.SetParent(myParent.transform);
        transform.localPosition = Vector3.zero;
    }
}
