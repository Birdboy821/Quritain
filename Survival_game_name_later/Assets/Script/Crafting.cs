using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public GameObject craftingBench;
    private InChest chest;
    private GameObject gameManager;
    private ItemManager itemManager;
    private GameObject craftingMenu;

    public string[,] recipeBookItems = new string[1, 5] { { "chest", "Wood", "null", "null", "null"} };
    public float[,] recipeBookCost = new float[1, 5] { {1, 8, 0, 0, 0} };

    public float canCraftTest = 0;
    int recipe;
    bool canCraft = false;
    // Start is called before the first frame update
    void Start()
    {
        chest = craftingBench.gameObject.GetComponent<InChest>();
        gameManager = GameObject.Find("GameManager");
        itemManager = gameManager.gameObject.GetComponent<ItemManager>();
        craftingMenu = GameObject.Find("CraftingMenu");
        craftingMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(recipeBookCost.Length);
        if(Input.GetKey("o"))
        {
            if (Input.GetKeyDown("0"))
            {
                recipe = 0;
                SearchForRequiredItems(recipe);
                if(canCraftTest == 4)
                {
                    canCraftTest = 0;
                    canCraft = true;
                    SearchForRequiredItems(recipe);
                    AddItem();
                }
                else
                {
                    canCraftTest = 0;
                    canCraft = false;
                }
                canCraftTest = 0;
            }
            else if (Input.GetKeyDown("1"))
            {
                recipe = 1;
                SearchForRequiredItems(recipe);
                if (canCraftTest == 4)
                {
                    canCraftTest = 0;
                    canCraft = true;
                    SearchForRequiredItems(recipe);
                    AddItem();
                }
                else
                {
                    canCraftTest = 0;
                    canCraft = false;
                }
                canCraftTest = 0;
            }
            else if (Input.GetKeyDown("2"))
            {
                recipe = 2;
                SearchForRequiredItems(recipe);
                if (canCraftTest == 4)
                {
                    canCraftTest = 0;
                    canCraft = true;
                    SearchForRequiredItems(recipe);
                    AddItem();
                }
                else
                {
                    canCraftTest = 0;
                    canCraft = false;
                }
                canCraftTest = 0;
            }
            else if (Input.GetKeyDown("3"))
            {
                recipe = 3;
                SearchForRequiredItems(recipe);
                if (canCraftTest == 4)
                {
                    canCraftTest = 0;
                    canCraft = true;
                    SearchForRequiredItems(recipe);
                    AddItem();
                }
                else
                {
                    canCraftTest = 0;
                    canCraft = false;
                }
                canCraftTest = 0;
            }
            else if (Input.GetKeyDown("4"))
            {
                recipe = 4;
                SearchForRequiredItems(recipe);
                if (canCraftTest == 4)
                {
                    canCraftTest = 0;
                    canCraft = true;
                    SearchForRequiredItems(recipe);
                    AddItem();
                }
                else
                {
                    canCraftTest = 0;
                    canCraft = false;
                }
                canCraftTest = 0;
            }
            else if (Input.GetKeyDown("5"))
            {
                recipe = 5;
                SearchForRequiredItems(recipe);
                if (canCraftTest == 4)
                {
                    canCraftTest = 0;
                    canCraft = true;
                    SearchForRequiredItems(recipe);
                    AddItem();
                }
                else
                {
                    canCraftTest = 0;
                    canCraft = false;
                }
                canCraftTest = 0;
            }
            else if (Input.GetKeyDown("6"))
            {
                recipe = 6;
                SearchForRequiredItems(recipe);
                if (canCraftTest == 4)
                {
                    canCraftTest = 0;
                    canCraft = true;
                    SearchForRequiredItems(recipe);
                    AddItem();
                }
                else
                {
                    canCraftTest = 0;
                    canCraft = false;
                }
                canCraftTest = 0;
            }
            else if (Input.GetKeyDown("7"))
            {
                recipe = 7;
                SearchForRequiredItems(recipe);
                if (canCraftTest == 4)
                {
                    canCraftTest = 0;
                    canCraft = true;
                    SearchForRequiredItems(recipe);
                    AddItem();
                }
                else
                {
                    canCraftTest = 0;
                    canCraft = false;
                }
                canCraftTest = 0;
            }
            else if (Input.GetKeyDown("8"))
            {
                recipe = 8;
                SearchForRequiredItems(recipe);
                if (canCraftTest == 4)
                {
                    canCraftTest = 0;
                    canCraft = true;
                    SearchForRequiredItems(recipe);
                    AddItem();
                }
                else
                {
                    canCraftTest = 0;
                    canCraft = false;
                }
                canCraftTest = 0;
            }
            else if (Input.GetKeyDown("9"))
            {
                recipe = 9;
                SearchForRequiredItems(recipe);
                if (canCraftTest == 4)
                {
                    canCraftTest = 0;
                    canCraft = true;
                    SearchForRequiredItems(recipe);
                    AddItem();
                }
                else
                {
                    canCraftTest = 0;
                    canCraft = false;
                }
                canCraftTest = 0;
            }
            //Debug.Log(itemManager.slotThreeImage.sprite == null);
            
        }
        if(chest.isInChest == true)
        {
            craftingMenu.gameObject.SetActive(true);
        } else if (chest.isInChest == false)
        {
            craftingMenu.gameObject.SetActive(false);
        }
    }

    private void AddItem()
    {
        for(int i = 0; i < itemManager.gameIcons.Length; i++)
        {
            Debug.Log(recipeBookItems[recipe, 0].Equals(itemManager.gameIcons[i].name) + " " + i);
            if(recipeBookItems[recipe, 0].Equals(itemManager.gameIcons[i].name))
            {
                FindEmptySlot(itemManager.gameIcons[i]);
                //temp.sprite = itemManager.gameIcons[i];
            }
        }
    }

    private void FindEmptySlot(Sprite itemGive)
    {
        if ((itemManager.slotOneImage.sprite == null || itemManager.slotOneImage.sprite == itemGive) && itemManager.slotOneStack < 50)
        {
            itemManager.slotOneImage.sprite = itemGive;
            itemManager.slotOneStack++;
        }
        else if ((itemManager.slotTwoImage.sprite == null || itemManager.slotTwoImage.sprite == itemGive) && itemManager.slotTwoStack < 50)
        {
            itemManager.slotTwoImage.sprite = itemGive;
            itemManager.slotTwoStack++;
        }
        else if ((itemManager.slotThreeImage.sprite == null || itemManager.slotThreeImage.sprite == itemGive) && itemManager.slotThreeStack < 50)
        {
            itemManager.slotThreeImage.sprite = itemGive;
            itemManager.slotThreeStack++;
        }
        else if ((itemManager.slotFourImage.sprite == null || itemManager.slotFourImage.sprite == itemGive) && itemManager.slotFourStack < 50)
        {
            itemManager.slotFourImage.sprite = itemGive;
            itemManager.slotFourStack++;
        }
    }

    private void SearchForRequiredItems(int searchForRecipe)
    {
        for(int d = 1; d < recipeBookItems.Length; d++)
        {
            if(!(recipeBookItems[searchForRecipe, d].Equals("null")))
            {
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0)
                    {
                        if ((itemManager.slotOneImage.sprite == null || itemManager.slotOneImage.sprite.name.Equals(recipeBookItems[searchForRecipe, d])))
                        {
                            if (recipeBookCost[searchForRecipe, d] <= itemManager.slotOneStack)
                            {
                                Debug.Log("Good");
                                i = 100000000;
                                canCraftTest++;
                                if(canCraft == true)
                                {
                                    itemManager.slotOneStack -= recipeBookCost[searchForRecipe, d];
                                    if(itemManager.slotOneStack == 0)
                                    {
                                        itemManager.slotOneImage.sprite = null;
                                    }
                                }
                            }
                        }
                    }
                    else if (i == 1)
                    {
                        if (itemManager.slotTwoImage.sprite == null || itemManager.slotTwoImage.sprite.name.Equals(recipeBookItems[searchForRecipe, d]))
                        {
                            if (recipeBookCost[searchForRecipe, d] <= itemManager.slotTwoStack)
                            {
                                Debug.Log("Good");
                                i = 100000000;
                                canCraftTest++;
                                if (canCraft == true)
                                {
                                    itemManager.slotTwoStack -= recipeBookCost[searchForRecipe, d];
                                    if (itemManager.slotTwoStack == 0)
                                    {
                                        itemManager.slotTwoImage.sprite = null;
                                    }
                                }
                            }
                        }
                    }
                    else if (i == 2)
                    {
                        if (itemManager.slotThreeImage.sprite == null || itemManager.slotThreeImage.sprite.name.Equals(recipeBookItems[searchForRecipe, d]))
                        {
                            if (recipeBookCost[searchForRecipe, d] <= itemManager.slotThreeStack)
                            {
                                Debug.Log("Good");
                                i = 100000000;
                                canCraftTest++;
                                if (canCraft == true)
                                {
                                    itemManager.slotThreeStack -= recipeBookCost[searchForRecipe, d];
                                    if (itemManager.slotThreeStack == 0)
                                    {
                                        itemManager.slotThreeImage.sprite = null;
                                    }
                                }
                            }
                        }
                    }
                    else if (i == 3)
                    {
                        if (itemManager.slotFourImage.sprite == null || itemManager.slotFourImage.sprite.name.Equals(recipeBookItems[searchForRecipe, d]))
                        {
                            if (recipeBookCost[searchForRecipe, d] <= itemManager.slotFourStack)
                            {
                                Debug.Log("Good");
                                i = 100000000;
                                canCraftTest++;
                                if (canCraft == true)
                                {
                                    itemManager.slotFourStack -= recipeBookCost[searchForRecipe, d];
                                    if (itemManager.slotFourStack == 0)
                                    {
                                        itemManager.slotFourImage.sprite = null;
                                    }
                                }
                            }
                        }
                    }
                    else if (i == 4)
                    {
                        if (chest.slot1Name == null || chest.slot1Name.name.Equals(recipeBookItems[searchForRecipe, d]))
                        {
                            if (recipeBookCost[searchForRecipe, d] <= chest.slotOneStack)
                            {
                                Debug.Log("Good");
                                i = 100000000;
                                canCraftTest++;
                                if (canCraft == true)
                                {
                                    chest.slotOneStack -= recipeBookCost[searchForRecipe, d];
                                    if (chest.slotOneStack == 0)
                                    {
                                        chest.chestSlot1.gameObject.GetComponent<Image>().sprite = null;
                                    }
                                }
                            }
                        }
                    }
                    else if (i == 5)
                    {
                        if (chest.slot2Name == null || chest.slot2Name.name.Equals(recipeBookItems[searchForRecipe, d]))
                        {
                            if (recipeBookCost[searchForRecipe, d] <= chest.slotTwoStack)
                            {
                                Debug.Log("Good");
                                i = 100000000;
                                canCraftTest++;
                                if (canCraft == true)
                                {
                                    chest.slotTwoStack -= recipeBookCost[searchForRecipe, d];
                                    if (chest.slotTwoStack == 0)
                                    {
                                        chest.chestSlot2.gameObject.GetComponent<Image>().sprite = null;
                                    }
                                }
                            }
                        }
                    }
                    else if (i == 6)
                    {
                        if (chest.slot3Name == null || chest.slot3Name.name.Equals(recipeBookItems[searchForRecipe, d]))
                        {
                            if (recipeBookCost[searchForRecipe, d] <= chest.slotThreeStack)
                            {
                                Debug.Log("Good");
                                i = 100000000;
                                canCraftTest++;
                                if (canCraft == true)
                                {
                                    chest.slotThreeStack -= recipeBookCost[searchForRecipe, d];
                                    if (chest.slotThreeStack == 0)
                                    {
                                        chest.chestSlot3.gameObject.GetComponent<Image>().sprite = null;
                                    }
                                }
                            }
                        }
                    }
                    else if (i == 7)
                    {
                        if (chest.slot4Name == null || chest.slot4Name.name.Equals(recipeBookItems[searchForRecipe, d]))
                        {
                            if (recipeBookCost[searchForRecipe, d] <= chest.slotFourStack)
                            {
                                Debug.Log("Good");
                                i = 100000000;
                                canCraftTest++;
                                if (canCraft == true)
                                {
                                    chest.slotFourStack -= recipeBookCost[searchForRecipe, d];
                                    if (chest.slotFourStack == 0)
                                    {
                                        chest.chestSlot4.gameObject.GetComponent<Image>().sprite = null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                canCraftTest++;
            }
        }
        Debug.Log(canCraftTest);
        
    }
}
