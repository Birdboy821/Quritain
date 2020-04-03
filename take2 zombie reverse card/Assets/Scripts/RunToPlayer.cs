using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody enemyRb;
    private GameObject player;
    public float speed = 3.0f;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player");
        if (player.transform.position.x >= transform.position.x-10 && player.transform.position.x <= transform.position.x + 10)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }
        
    }
}
