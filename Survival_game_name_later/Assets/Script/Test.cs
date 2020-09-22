using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool isInChest = false;
    private GameObject inventory;
    public GameObject cameraPlayer;
    // Start is called before the first frame update
    void Start()
    {
        cameraPlayer = GameObject.Find("Main Camera");
        inventory = GameObject.Find("Inventory");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        
        if(Input.GetKeyDown("x") && isInChest == false)
        {
            //Debug.Log("Mouse is over GameObject.");
            isInChest = true;
            cameraPlayer.gameObject.GetComponent<MouseLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            inventory.gameObject.SetActive(true);
        }
        if(isInChest == false)
        {
            inventory.gameObject.SetActive(false);
            cameraPlayer.gameObject.GetComponent<MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //Debug.Log("Mouse is no longer on GameObject.");
    }
}
