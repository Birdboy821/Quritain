using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class GameManager2 : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameManager gameManager;

    public TextMeshProUGUI pinkText;
    public TextMeshProUGUI moveText;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager1");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.numberOfHumansAlive != gameManager.numberOfHumans)
        {
            pinkText.gameObject.SetActive(false);
            moveText.gameObject.SetActive(false);
        }
        if(GameObject.FindGameObjectsWithTag("Zombie").Length == 0)
        {
            pinkText.gameObject.SetActive(false);
            moveText.gameObject.SetActive(false);
        }
    }
}
