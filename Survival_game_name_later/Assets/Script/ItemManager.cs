using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject leftArm;
    public GameObject rightArm;

    public Sprite[] gameIcons;
    public GameObject[] tools;
    public GameObject slotOne; //hotbar
    public GameObject slotTwo; //hotbar
    public GameObject slotThree; //inventory
    public GameObject slotFour; //inventory

    public Image slotOneImage; //hotbar
    public float slotOneStack = 0;
    public TextMeshProUGUI slotOneText;
    public Image slotTwoImage; //hotbar
    public float slotTwoStack = 0;
    public TextMeshProUGUI slotTwoText;
    public Image slotThreeImage; //inventory
    public float slotThreeStack = 0;
    public TextMeshProUGUI slotThreeText;
    public Image slotFourImage; //inventory
    public float slotFourStack = 0;
    public TextMeshProUGUI slotFourText;

    public Sprite itemName;
    public bool itemGrab = false;
    public Color highlighted = new Color(1, 0.73f, 0, 0.2352f);
    public Color background;
    public Image clicked;
    public Sprite itemClicked;
    public float itemClickedStackSize;
    public TextMeshProUGUI clickedText;
    // Start is called before the first frame update
    void Start()
    {
        slotOneImage =  slotOne.gameObject.GetComponent<Image>();
        slotTwoImage = slotTwo.gameObject.GetComponent<Image>();
        slotThreeImage = slotThree.gameObject.GetComponent<Image>();
        slotFourImage = slotFour.gameObject.GetComponent<Image>();
        background = slotOneImage.color;
        slotOneImage.sprite = gameIcons[0];
        slotOneStack = 1;
        UpdateNumbers();
        HandyMan();
    }

    // Update is called once per frame
    void Update()
    {
        ItemSwitch();
        UpdateNumbers();
        
    }

    private void HandyMan()
    {
        for(int i = 0; i < gameIcons.Length; i++)
        {
            //Debug.Log(gameIcons[i].name + " " + slotOneImage.sprite.name);
            if(gameIcons[i].name == slotOneImage.sprite.name)
            {
                GameObject gFloor = Instantiate(tools[i]);
                gFloor.transform.parent = leftArm.transform;
                gFloor.transform.localPosition = new Vector3(0.1f, 0.26f, 0.25f);
                gFloor.transform.rotation = Quaternion.Euler(0, 90, 0);
                gFloor.transform.localScale = new Vector3(1, 2, 2);
                //Debug.Log(i);
            }
            if (gameIcons[i].name == slotTwoImage.sprite.name)
            {
                GameObject gFloor = Instantiate(tools[i]);
                gFloor.transform.parent = rightArm.transform;
                gFloor.transform.localPosition = new Vector3(0.1f, 0.26f, 0.25f);
                gFloor.transform.rotation = Quaternion.Euler(0, 90, 0);
                gFloor.transform.localScale = new Vector3(1, 2, 2);
                //Debug.Log(i);
            }
        }
    }

    public void UpdateNumbers()
    {
        slotOneText.text = slotOneStack + "";
        slotTwoText.text = slotTwoStack + "";
        slotThreeText.text = slotThreeStack + "";
        slotFourText.text = slotFourStack + "";
    }
    public void UpdateStack()
    {
        slotOneStack = float.Parse(slotOneText.text);
        slotTwoStack = float.Parse(slotTwoText.text);
        slotThreeStack = float.Parse(slotThreeText.text);
        slotFourStack = float.Parse(slotFourText.text);
    }

    private void ItemSwitch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            //Debug.Log(mousePos);
            if (mousePos.x >= 780 && mousePos.x <= 930 && mousePos.y >= 55 && mousePos.y <= 200 && itemGrab == false)
            {
                //Debug.Log("Slot 1");
                itemName = slotOneImage.sprite;
                //Debug.Log(itemName);
                slotOneImage.color = highlighted;
                itemGrab = true;
                clicked = slotOneImage;
                itemClicked = slotOneImage.sprite;
                itemClickedStackSize = slotOneStack;
                clickedText = slotOneText;
            }
            else if (mousePos.x >= 980 && mousePos.x <= 1135 && mousePos.y >= 55 && mousePos.y <= 200 && itemGrab == false)
            {
                //Debug.Log("Slot 2");
                itemName = slotTwoImage.sprite;
                //Debug.Log(itemName);
                slotTwoImage.color = highlighted;
                itemGrab = true;
                clicked = slotTwoImage;
                itemClicked = slotTwoImage.sprite;
                itemClickedStackSize = slotTwoStack;
                clickedText = slotTwoText;
            }
            else if (mousePos.x >= 780 && mousePos.x <= 930 && mousePos.y >= 314 && mousePos.y <= 470 && itemGrab == false)
            {
                //Debug.Log("Slot 3");
                itemName = slotThreeImage.sprite;
                //Debug.Log(itemName);
                slotThreeImage.color = highlighted;
                itemGrab = true;
                clicked = slotThreeImage;
                itemClicked = slotThreeImage.sprite;
                itemClickedStackSize = slotThreeStack;
                clickedText = slotThreeText;
            }
            else if (mousePos.x >= 980 && mousePos.x <= 1135 && mousePos.y >= 314 && mousePos.y <= 470 && itemGrab == false)
            {
                //Debug.Log("Slot 4");
                itemName = slotFourImage.sprite;
                //Debug.Log(itemName);
                slotFourImage.color = highlighted;
                itemGrab = true;
                clicked = slotFourImage;
                itemClicked = slotFourImage.sprite;
                itemClickedStackSize = slotFourStack;
                clickedText = slotFourText;
            }
            else if (mousePos.x >= 780 && mousePos.x <= 930 && mousePos.y >= 55 && mousePos.y <= 200 && itemGrab == true && slotOneImage != clicked)
            {
                //Debug.Log("Slot 1");
                itemName = slotOneImage.sprite;
                //Debug.Log(itemName);
                slotOneImage.color = background;
                clicked.color = background;
                itemGrab = false;
                clicked.sprite = slotOneImage.sprite;
                slotOneImage.sprite = itemClicked;
                clickedText.text = slotOneStack + "";
                slotOneText.text = itemClickedStackSize + "";
                UpdateStack();
            }
            else if (mousePos.x >= 980 && mousePos.x <= 1135 && mousePos.y >= 55 && mousePos.y <= 200 && itemGrab == true && slotTwoImage != clicked)
            {
                //Debug.Log("Slot 2");
                itemName = slotTwoImage.sprite;
                //Debug.Log(itemName);
                clicked.color = background;
                slotTwoImage.color = background;
                itemGrab = false;
                clicked.sprite = slotTwoImage.sprite;
                slotTwoImage.sprite = itemClicked;
                clickedText.text = slotTwoStack + "";
                slotTwoText.text = itemClickedStackSize + "";
                UpdateStack();
            }
            else if (mousePos.x >= 783 && mousePos.x <= 930 && mousePos.y >= 314 && mousePos.y <= 470 && itemGrab == true && slotThreeImage != clicked)
            {
                //Debug.Log("Slot 3");
                itemName = slotOneImage.sprite;
                //Debug.Log(itemName);
                slotThreeImage.color = background;
                clicked.color = background;
                itemGrab = false;
                clicked.sprite = slotThreeImage.sprite;
                slotThreeImage.sprite = itemClicked;
                clickedText.text = slotThreeStack + "";
                slotThreeText.text = itemClickedStackSize + "";
                UpdateStack();
            }
            else if (mousePos.x >= 980 && mousePos.x <= 1135 && mousePos.y >= 314 && mousePos.y <= 470 && itemGrab == true && slotFourImage != clicked)
            {
                //Debug.Log("Slot 4");
                itemName = slotFourImage.sprite;
                //Debug.Log(itemName);
                clicked.color = background;
                slotFourImage.color = background;
                itemGrab = false;
                clicked.sprite = slotFourImage.sprite;
                slotFourImage.sprite = itemClicked;
                clickedText.text = slotFourStack + "";
                slotFourText.text = itemClickedStackSize + "";
                UpdateStack();
            }
        }
    }
}
