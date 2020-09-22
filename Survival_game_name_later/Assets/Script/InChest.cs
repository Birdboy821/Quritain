using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InChest : MonoBehaviour
{
    public GameObject chest;
    private Test chestScript;
    private GameObject crosshair;
    private GameObject chestInterface;
    private GameObject gameManager;
    private ItemManager itemManager;
    public GameObject chestSlot1;
    public GameObject chestSlot2;
    public GameObject chestSlot3;
    public GameObject chestSlot4;

    public GameObject chestSlot1Temp;
    public GameObject chestSlot2Temp;
    public GameObject chestSlot3Temp;
    public GameObject chestSlot4Temp;

    public float slotOneSaveStack;
    public float slotTwoSaveStack;
    public float slotThreeSaveStack;
    public float slotFourSaveStack;

    public Sprite slot1;
    public float slotOneStack = 0;
    public TextMeshProUGUI slotOneText;
    public Sprite slot2;
    public float slotTwoStack = 0;
    public TextMeshProUGUI slotTwoText;
    public Sprite slot3;
    public float slotThreeStack = 0;
    public TextMeshProUGUI slotThreeText;
    public Sprite slot4;
    public float slotFourStack = 0;
    public TextMeshProUGUI slotFourText;

    public bool open = false;
    public bool isInChest;

    public Sprite slot1Name;
    public Sprite slot2Name;
    public Sprite slot3Name;
    public Sprite slot4Name;

    // Start is called before the first frame update
    void Start()
    {
        chestScript = chest.gameObject.GetComponent<Test>();
        crosshair = GameObject.Find("Crosshair");
        chestInterface = GameObject.Find("ChestInterface");
        gameManager = GameObject.Find("GameManager");
        itemManager = gameManager.gameObject.GetComponent<ItemManager>();
        chestSlot1 = GameObject.Find("ChestSlot1");
        chestSlot2 = GameObject.Find("ChestSlot2");
        chestSlot3 = GameObject.Find("ChestSlot3");
        chestSlot4 = GameObject.Find("ChestSlot4");

        chestSlot1Temp = GameObject.Find("Slot1TextChest");
        chestSlot2Temp = GameObject.Find("Slot2TextChest");
        chestSlot3Temp = GameObject.Find("Slot3TextChest");
        chestSlot4Temp = GameObject.Find("Slot4TextChest");

        slotOneText = chestSlot1Temp.GetComponent<TextMeshProUGUI>();
        slotTwoText = chestSlot2Temp.GetComponent<TextMeshProUGUI>();
        slotThreeText = chestSlot3Temp.GetComponent<TextMeshProUGUI>();
        slotFourText = chestSlot4Temp.GetComponent<TextMeshProUGUI>();

        UpdateNumbers();

        
    }

    // Update is called once per frame
    void Update()
    {
        slot1Name = chestSlot1.gameObject.GetComponent<Image>().sprite;
        slot2Name = chestSlot2.gameObject.GetComponent<Image>().sprite;
        slot3Name = chestSlot3.gameObject.GetComponent<Image>().sprite;
        slot4Name = chestSlot4.gameObject.GetComponent<Image>().sprite;

        isInChest = chestScript.isInChest;
        if (Input.GetKeyDown("q") && chestScript.isInChest == true)
        {
            chestScript.isInChest = false;
            crosshair.gameObject.SetActive(true);
            chestInterface.gameObject.SetActive(false);
            open = false;
            SlotSaver();

        }
        if(chestScript.isInChest == true)
        {
            //Debug.Log(gameObject.name);
            crosshair.gameObject.SetActive(false);
            chestInterface.gameObject.SetActive(true);
            if(open == false)
            {
                open = true;
                SlotUser();
                UpdateNumbers();
            }

            if (Input.GetMouseButtonDown(0))
            {
                ChestItem();
            }
            
        }
        if (Input.GetKeyDown("p"))
        {
            itemManager.clicked.sprite = chestSlot1.gameObject.GetComponent<Image>().sprite;
            chestSlot1.gameObject.GetComponent<Image>().sprite = itemManager.itemClicked;
            itemManager.clicked.color = itemManager.background;
            
        }
        UpdateStack();
        UpdateNumbers();
        
    }

    private void UpdateNumbers()
    {
        slotOneText.text = slotOneStack + "";
        slotTwoText.text = slotTwoStack + "";
        slotThreeText.text = slotThreeStack + "";
        slotFourText.text = slotFourStack + "";
    }
    private void UpdateStack()
    {
        slotOneStack = float.Parse(slotOneText.text);
        slotTwoStack = float.Parse(slotTwoText.text);
        slotThreeStack = float.Parse(slotThreeText.text);
        slotFourStack = float.Parse(slotFourText.text);
    }

    private void SlotSaver()
    {
        slot1 = chestSlot1.gameObject.GetComponent<Image>().sprite;
        slot2 = chestSlot2.gameObject.GetComponent<Image>().sprite;
        slot3 = chestSlot3.gameObject.GetComponent<Image>().sprite;
        slot4 = chestSlot4.gameObject.GetComponent<Image>().sprite;
        
        slotOneSaveStack = slotOneStack;
        slotTwoSaveStack = slotTwoStack;
        slotThreeSaveStack = slotThreeStack;
        slotFourSaveStack = slotFourStack;
        slotOneStack = 0;
        slotTwoStack = 0;
        slotThreeStack = 0;
        slotFourStack = 0;
    }
    private void SlotUser()
    {
        chestSlot1.gameObject.GetComponent<Image>().sprite = slot1;
        chestSlot2.gameObject.GetComponent<Image>().sprite = slot2;
        chestSlot3.gameObject.GetComponent<Image>().sprite = slot3;
        chestSlot4.gameObject.GetComponent<Image>().sprite = slot4;

        slotOneStack = slotOneSaveStack;
        slotTwoStack = slotTwoSaveStack;
        slotThreeStack = slotThreeSaveStack;
        slotFourStack = slotFourSaveStack;
    }

    private void ChestItem()
    {
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x >= 780 && mousePos.x <= 930 && mousePos.y >= 570 && mousePos.y <= 705 && itemManager.itemGrab == false)
        {
            //Debug.Log("Slot 1");
            itemManager.itemName = chestSlot1.gameObject.GetComponent<Image>().sprite;
            //Debug.Log(itemManager.itemName);
            chestSlot1.gameObject.GetComponent<Image>().color = itemManager.highlighted;
            itemManager.itemGrab = true;
            itemManager.clicked = chestSlot1.gameObject.GetComponent<Image>();
            itemManager.itemClicked = chestSlot1.gameObject.GetComponent<Image>().sprite;
            itemManager.itemClickedStackSize = slotOneStack;
            itemManager.clickedText = slotOneText;
        }
        else if (mousePos.x >= 980 && mousePos.x <= 1135 && mousePos.y >= 570 && mousePos.y <= 705 && itemManager.itemGrab == false)
        {
            //Debug.Log("Slot 2");
            itemManager.itemName = chestSlot2.gameObject.GetComponent<Image>().sprite;
            //Debug.Log(itemManager.itemName);
            chestSlot2.gameObject.GetComponent<Image>().color = itemManager.highlighted;
            itemManager.itemGrab = true;
            itemManager.clicked = chestSlot2.gameObject.GetComponent<Image>();
            itemManager.itemClicked = chestSlot2.gameObject.GetComponent<Image>().sprite;
            itemManager.itemClickedStackSize = slotTwoStack;
            itemManager.clickedText = slotTwoText;
        }
        else if (mousePos.x >= 780 && mousePos.x <= 930 && mousePos.y >= 765 && mousePos.y <= 910 && itemManager.itemGrab == false)
        {
            //Debug.Log("Slot 3");
            itemManager.itemName = chestSlot3.gameObject.GetComponent<Image>().sprite;
            //Debug.Log(itemManager.itemName);
            chestSlot3.gameObject.GetComponent<Image>().color = itemManager.highlighted;
            itemManager.itemGrab = true;
            itemManager.clicked = chestSlot3.gameObject.GetComponent<Image>();
            itemManager.itemClicked = chestSlot3.gameObject.GetComponent<Image>().sprite;
            itemManager.itemClickedStackSize = slotThreeStack;
            itemManager.clickedText = slotThreeText;
        }
        else if (mousePos.x >= 980 && mousePos.x <= 1135 && mousePos.y >= 765 && mousePos.y <= 910 && itemManager.itemGrab == false)
        {
            //Debug.Log("Slot 4");
            itemManager.itemName = chestSlot4.gameObject.GetComponent<Image>().sprite;
            //Debug.Log(itemManager.itemName);
            chestSlot4.gameObject.GetComponent<Image>().color = itemManager.highlighted;
            itemManager.itemGrab = true;
            itemManager.clicked = chestSlot4.gameObject.GetComponent<Image>();
            itemManager.itemClicked = chestSlot4.gameObject.GetComponent<Image>().sprite;
            itemManager.itemClickedStackSize = slotFourStack;
            itemManager.clickedText = slotFourText;
        }
        else if (mousePos.x >= 780 && mousePos.x <= 930 && mousePos.y >= 570 && mousePos.y <= 705 && itemManager.itemGrab == true && chestSlot1 != itemManager.clicked)
        {
            //Debug.Log("Slot 4");
            itemManager.itemName = chestSlot1.gameObject.GetComponent<Image>().sprite;
            //Debug.Log(itemManager.itemName);
            itemManager.clicked.color = itemManager.background;
            chestSlot1.gameObject.GetComponent<Image>().color = itemManager.background;
            itemManager.itemGrab = false;
            itemManager.clicked.sprite = chestSlot1.gameObject.GetComponent<Image>().sprite;
            chestSlot1.gameObject.GetComponent<Image>().sprite = itemManager.itemClicked;
            itemManager.clickedText.text = slotOneStack + "";
            slotOneText.text = itemManager.itemClickedStackSize + "";
            UpdateStack();
            itemManager.UpdateStack();
        }
        else if (mousePos.x >= 980 && mousePos.x <= 1135 && mousePos.y >= 570 && mousePos.y <= 705 && itemManager.itemGrab == true && chestSlot2 != itemManager.clicked)
        {
            //Debug.Log("Slot 4");
            itemManager.itemName = chestSlot2.gameObject.GetComponent<Image>().sprite;
            //Debug.Log(itemManager.itemName);
            itemManager.clicked.color = itemManager.background;
            chestSlot2.gameObject.GetComponent<Image>().color = itemManager.background;
            itemManager.itemGrab = false;
            itemManager.clicked.sprite = chestSlot2.gameObject.GetComponent<Image>().sprite;
            chestSlot2.gameObject.GetComponent<Image>().sprite = itemManager.itemClicked;
            itemManager.clickedText.text = slotTwoStack + "";
            slotTwoText.text = itemManager.itemClickedStackSize + "";
            UpdateStack();
            itemManager.UpdateStack();
        }
        else if (mousePos.x >= 780 && mousePos.x <= 930 && mousePos.y >= 765 && mousePos.y <= 910 && itemManager.itemGrab == true && chestSlot3 != itemManager.clicked)
        {
            //Debug.Log("Slot 4");
            itemManager.itemName = chestSlot3.gameObject.GetComponent<Image>().sprite;
            //Debug.Log(itemManager.itemName);
            itemManager.clicked.color = itemManager.background;
            chestSlot3.gameObject.GetComponent<Image>().color = itemManager.background;
            itemManager.itemGrab = false;
            itemManager.clicked.sprite = chestSlot3.gameObject.GetComponent<Image>().sprite;
            chestSlot3.gameObject.GetComponent<Image>().sprite = itemManager.itemClicked;
            itemManager.clickedText.text = slotThreeStack + "";
            slotThreeText.text = itemManager.itemClickedStackSize + "";
            UpdateStack();
            itemManager.UpdateStack();
        }
        else if (mousePos.x >= 980 && mousePos.x <= 1135 && mousePos.y >= 765 && mousePos.y <= 910 && itemManager.itemGrab == true && chestSlot4 != itemManager.clicked)
        {
            //Debug.Log("Slot 4");
            itemManager.itemName = chestSlot4.gameObject.GetComponent<Image>().sprite;
            //Debug.Log(itemManager.itemName);
            itemManager.clicked.color = itemManager.background;
            chestSlot4.gameObject.GetComponent<Image>().color = itemManager.background;
            itemManager.itemGrab = false;
            itemManager.clicked.sprite = chestSlot4.gameObject.GetComponent<Image>().sprite;
            chestSlot4.gameObject.GetComponent<Image>().sprite = itemManager.itemClicked;
            itemManager.clickedText.text = slotFourStack + "";
            slotFourText.text = itemManager.itemClickedStackSize + "";
            UpdateStack();
            itemManager.UpdateStack();
        }
    }
}
