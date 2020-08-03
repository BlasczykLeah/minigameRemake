using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [Header("Hotbar Links")]
    public GameObject[] hotbar;
    public Attack[] weaponScripts;
    public int hotbarCount;
    public int activeWeapon = 0;

    [Header("Inventory Elements")]
    public GameObject InventoryPanel;
    public GameObject myCamera;
    bool inInventory = false;

    float scrollValue, currScrollVal;

    // Start is called before the first frame update
    void Start()
    {
        InventoryActive(false);
        scrollValue = currScrollVal = Input.GetAxisRaw("Mouse ScrollWheel");
    }

    // Update is called once per frame
    void Update()
    {
        if (!inInventory)
        {
            currScrollVal -= Input.GetAxisRaw("Mouse ScrollWheel");

            if (currScrollVal != scrollValue)
            {
                Debug.Log(currScrollVal);

                if (currScrollVal < scrollValue) WeaponSwap(false);
                if (currScrollVal > scrollValue) WeaponSwap(true);

                scrollValue = currScrollVal;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inInventory = !inInventory;
            InventoryActive(inInventory);
        }
    }

    void WeaponSwap(bool movedUp)
    {
        DisableCurrentWeapon(activeWeapon);
        int newWeapon = activeWeapon;

        if (hotbarCount <= 0)
        {
            activeWeapon = -1;
            return;
        }

        if(movedUp)
        {
            // check if another weapon available if ++, else go to 0
            newWeapon++;
            if (newWeapon + 1 >= hotbar.Length) newWeapon = 0;
            Debug.Log("Checking for weapon at index " + newWeapon);

            while (hotbar[newWeapon] == null)
            {
                newWeapon++;
                Debug.Log("Checking for weapon at index " + newWeapon);
                if (newWeapon >= hotbar.Length) newWeapon = 0;

                if (newWeapon == activeWeapon) continue;
            }

            if (newWeapon == activeWeapon && hotbar[newWeapon] == null)
            {
                Debug.Log("No weapons on hotbar.");
                activeWeapon = -1;
                return;
            }
            Debug.Log("Weapon found at index " + newWeapon);
        }
        else
        {
            // if activeWeapon == 0, activeWeapon = weapons.Count - 1, else --
            newWeapon--;
            if (newWeapon < 0) newWeapon = hotbar.Length - 1;
            Debug.Log("Checking for weapon at index " + newWeapon);

            while (hotbar[newWeapon] == null)
            {
                newWeapon--;
                Debug.Log("Checking for weapon at index " + newWeapon);
                if (newWeapon < 0) newWeapon = hotbar.Length - 1;

                if (newWeapon == activeWeapon) continue;
            }

            if (newWeapon == activeWeapon && hotbar[newWeapon] == null)
            {
                Debug.Log("No weapons on hotbar.");
                activeWeapon = -1;
                return;
            }
            Debug.Log("Weapon found at index " + newWeapon);
        }

        activeWeapon = newWeapon;
        SetActiveWeapon(activeWeapon);
    }

    void DisableCurrentWeapon(int index)
    {
        // turn off gameobject and make sure any needed code is unactive
        if (index == -1) return;

        if (hotbar[index] != null)
        {
            hotbar[index].SetActive(false);
            weaponScripts[index].enabled = false;
        }
    }

    void SetActiveWeapon(int index)
    {
        // turn on gameobject and make sure any needed code is active
        hotbar[index].SetActive(true);
        weaponScripts[index].enabled = true;
    }

    void InventoryActive(bool isActive)
    {
        if (isActive)
        {
            Cursor.visible = true;
            if (activeWeapon != -1) DisableCurrentWeapon(activeWeapon);
            GetComponent<PlayerMovement>().enabled = false;
            myCamera.GetComponent<CameraMovement>().enabled = false;
            InventoryPanel.SetActive(true);
        }
        else
        {
            Cursor.visible = false;
            if(activeWeapon != -1) SetActiveWeapon(activeWeapon);
            GetComponent<PlayerMovement>().enabled = true;
            myCamera.GetComponent<CameraMovement>().enabled = true;
            InventoryPanel.SetActive(false);
        }
    }

    public void AddWeaponHotbar(int index, GameObject weapon, Attack weaponScript)
    {
        if (hotbar[index] == null)
        {
            Debug.Log("Adding " + weapon.name + " at slot " + index);

            hotbar[index] = weapon;
            weaponScripts[index] = weaponScript;
            hotbarCount++;

            if (activeWeapon == -1) activeWeapon = index;
        }
        else Debug.Log("Something is already here");
    }

    public void RemoveWeaponHotbar(int index)
    {
        if (hotbar[index] == null) Debug.Log("There is no weapon here.");
        else
        {
            hotbar[index] = null;
            weaponScripts[index] = null;
            hotbarCount--;

            if (activeWeapon == index)
            {
                WeaponSwap(true);
                DisableCurrentWeapon(activeWeapon);
            }
        }
    }
}
