using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public GameObject inventory;
    private bool openClose = false;
    public GameObject cameraPlayer;
    private GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        //inventory = GameObject.Find("Inventory");
        cameraPlayer = GameObject.Find("Main Camera");
        crosshair = GameObject.Find("Crosshair");
        //Debug.Log(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && openClose == false)
        {
            inventory.gameObject.SetActive(true);
            openClose = true;
            Cursor.lockState = CursorLockMode.None;
            cameraPlayer.gameObject.GetComponent<MouseLook>().enabled = false;
            crosshair.gameObject.SetActive(false);
        }
        else if(Input.GetKeyDown("e") && openClose == true)
        {
            inventory.gameObject.SetActive(false);
            openClose = false;
            Cursor.lockState = CursorLockMode.Locked;
            cameraPlayer.gameObject.GetComponent<MouseLook>().enabled = true;
            crosshair.gameObject.SetActive(true);
        }
    }
}
