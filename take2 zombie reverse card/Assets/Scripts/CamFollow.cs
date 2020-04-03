using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        player = GameObject.Find("player");
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }
}
