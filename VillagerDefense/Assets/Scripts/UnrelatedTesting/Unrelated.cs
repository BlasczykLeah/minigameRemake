using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unrelated : MonoBehaviour
{
    public Text thing;
    string keyToUpdate;
    bool updatingKey = false;

    // Start is called before the first frame update
    void Start()
    {
        thing.text = "f";
    }

    // Update is called once per frame
    void Update()
    {
        if (updatingKey)
        {
            if (Input.anyKeyDown)
            {
                /*string i = Input.inputString.ToUpper();
                thing.text = i;

                KeyCode k = (KeyCode)System.Enum.Parse(typeof(KeyCode), i);

                MyInputManager.SetNewKey(keyToUpdate, k);
                keyToUpdate = "";
                updatingKey = false;
                */

                foreach (KeyCode k in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(k))
                    {
                        MyInputManager.SetNewKey(keyToUpdate, k);
                        thing.text = k.ToString();

                        Debug.Log(thing.text + " key set to " + k.ToString());

                        keyToUpdate = "";
                        updatingKey = false;
                        thing.transform.parent.GetComponent<Button>().interactable = true;
                        return;
                    }
                }
            }
        }

        if (MyInputManager.GetKeyDown("Thing"))
        {
            Debug.Log("I have push the key!");
        }
    }

    public void changeButton(int index)
    {
        keyToUpdate = MyInputManager.GetKeyFromIndex(index);
        updatingKey = true;
        thing.text = "...";
        thing.transform.parent.GetComponent<Button>().interactable = false;
    }
}
