using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    private GameObject gameManager;
    private ItemManager itemManager;

    public Sprite itemGive;
    public Sprite properTool;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        itemManager = gameManager.gameObject.GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ItemGiveEnvornment()
    {
        if((itemManager.slotOneImage.sprite == null || itemManager.slotOneImage.sprite == itemGive) && itemManager.slotOneStack < 50)
        {
            itemManager.slotOneImage.sprite = itemGive;
            itemManager.slotOneStack++;
        } else if ((itemManager.slotTwoImage.sprite == null || itemManager.slotTwoImage.sprite == itemGive) && itemManager.slotTwoStack < 50)
        {
            itemManager.slotTwoImage.sprite = itemGive;
            itemManager.slotTwoStack++;
        } else if ((itemManager.slotThreeImage.sprite == null || itemManager.slotThreeImage.sprite == itemGive) && itemManager.slotThreeStack < 50)
        {
            itemManager.slotThreeImage.sprite = itemGive;
            itemManager.slotThreeStack++;
        } else if ((itemManager.slotFourImage.sprite == null || itemManager.slotFourImage.sprite == itemGive) && itemManager.slotFourStack < 50)
        {
            itemManager.slotFourImage.sprite = itemGive;
            itemManager.slotFourStack++;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && (properTool == itemManager.slotOneImage.sprite || properTool == null))
        {
            ItemGiveEnvornment();
        }
        else if (Input.GetMouseButtonDown(1) && (properTool == itemManager.slotTwoImage.sprite || properTool == null))
        {
            ItemGiveEnvornment();
        }
    }
}
