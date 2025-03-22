using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Could_spawner : MonoBehaviour
{
    public GameObject Cloud_1;
    public GameObject Cloud_2;
    public GameObject Cloud_3;
    public GameObject Cloud_4;
    public GameObject Cloud_5;

    public Vector2 CloudSpawn;
    public float Cloud_y;

    static int CloudNumber = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (CloudNumber < 5)
        {
            Cloud_y = Random.Range(-5f, 5f);
            CloudSpawn = new Vector2(transform.position.x, transform.position.y + Cloud_y);
            GameObject cloud = Instantiate(Cloud_1, CloudSpawn, Quaternion.identity);
            CloudNumber++;
        }
    }
}
