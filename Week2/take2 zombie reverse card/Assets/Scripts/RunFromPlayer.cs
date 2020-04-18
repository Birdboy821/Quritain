using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFromPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody enemyRb;
    private GameObject player;

    public float speed = 10;
    public float xDifferce;
    public float zDifferce;
    public float highpotanos;
    public float angleA;
    public float angleB;
    public float angleC = 90;

    public Animation walk;
    public float clock = 0;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
        player = GameObject.Find("player");
        xDifferce = Mathf.Abs(player.transform.position.x - gameObject.transform.position.x);
        zDifferce = Mathf.Abs(player.transform.position.z - gameObject.transform.position.z);
        highpotanos = Mathf.Sqrt(Mathf.Pow(xDifferce, 2) + Mathf.Pow(zDifferce, 2));

        angleA = Mathf.Acos((Mathf.Pow(zDifferce, 2) + Mathf.Pow(highpotanos, 2) - Mathf.Pow(xDifferce, 2)) / (2 * zDifferce * highpotanos)) * (180 / Mathf.PI);
        angleB = Mathf.Acos((Mathf.Pow(xDifferce, 2) + Mathf.Pow(highpotanos, 2) - Mathf.Pow(zDifferce, 2)) / (2 * xDifferce * highpotanos)) * (180 / Mathf.PI);



        if (player.transform.position.x - gameObject.transform.position.x > 0 && player.transform.position.z - gameObject.transform.position.z > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -angleA - 90, 0);
        }
        else if (player.transform.position.x - gameObject.transform.position.x <= 0 && player.transform.position.z - gameObject.transform.position.z > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, angleA + 90, 0);
        }
        else if (player.transform.position.x - gameObject.transform.position.x > 0 && player.transform.position.z - gameObject.transform.position.z <= 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -angleA, 0);
        }
        else if (player.transform.position.x - gameObject.transform.position.x <= 0 && player.transform.position.z - gameObject.transform.position.z <= 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, angleA, 0);
        }
        if (player.transform.position.x >= transform.position.x - 10 && player.transform.position.x <= transform.position.x + 10)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddRelativeForce(Vector3.forward * speed);
        }
    }
}
