using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public GameObject player;
    public float xDifferce;
    public float zDifferce;
    public float highpotanos;
    public float angleA;
    public float angleB;
    public float angleC = 90;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xDifferce = Mathf.Abs(player.transform.position.x - gameObject.transform.position.x);
        zDifferce = Mathf.Abs(player.transform.position.z - gameObject.transform.position.z);
        highpotanos = Mathf.Sqrt(Mathf.Pow(xDifferce, 2) + Mathf.Pow(zDifferce, 2));

        angleA = Mathf.Acos((Mathf.Pow(zDifferce, 2) + Mathf.Pow(highpotanos, 2) - Mathf.Pow(xDifferce, 2)) / (2 * zDifferce * highpotanos)) * (180 / Mathf.PI);
        angleB = Mathf.Acos((Mathf.Pow(xDifferce, 2) + Mathf.Pow(highpotanos, 2) - Mathf.Pow(zDifferce, 2)) / (2 * xDifferce * highpotanos)) * (180 / Mathf.PI);

        

        if(player.transform.position.x - gameObject.transform.position.x >= 0 && player.transform.position.z - gameObject.transform.position.z >= 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -angleA - 90, 0);
        } else if (player.transform.position.x - gameObject.transform.position.x <= 0 && player.transform.position.z - gameObject.transform.position.z >= 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, angleA + 90, 0);
        } else if (player.transform.position.x - gameObject.transform.position.x >= 0 && player.transform.position.z - gameObject.transform.position.z <= 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -angleA, 0);
        }
        else if (player.transform.position.x - gameObject.transform.position.x <= 0 && player.transform.position.z - gameObject.transform.position.z <= 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, angleA, 0);
        }
    }
}
