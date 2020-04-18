using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieDieDieDied : MonoBehaviour
{
    public GameObject gameManagerObject;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager1");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zombie") || other.CompareTag("Human"))
        {
            Destroy(other.gameObject);
            if(other.CompareTag("Human"))
            {
                gameManager.numberOfHumansAlive--;
            }
        }
        
    }
}
