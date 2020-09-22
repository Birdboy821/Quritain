using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject chestInterface;
    public GameObject inventory;
    private Vector3 playerPosNew;
    private Vector3 playerPosOld;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        chestInterface.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerPosNew = player.gameObject.transform.position;

        if(playerPosNew.x >= 50)
        {
            player.gameObject.transform.position = new Vector3(48, playerPosNew.y, playerPosNew.z);
            //Debug.Log("1");
        }
        else if (playerPosNew.x <= -50)
        {
            player.gameObject.transform.position = new Vector3(-48, playerPosNew.y, playerPosNew.z);
            //Debug.Log("2");
        }
        else if (playerPosNew.z >= 50)
        {
            player.gameObject.transform.position = new Vector3(playerPosNew.x, playerPosNew.y, 48);
            //Debug.Log("3");
        }
        else if (playerPosNew.z <= -50)
        {
            player.gameObject.transform.position = new Vector3(playerPosNew.x, playerPosNew.y, -48);
            //Debug.Log("4");
        }
    }
}
