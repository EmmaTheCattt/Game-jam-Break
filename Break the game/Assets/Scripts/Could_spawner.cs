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

    [SerializeField]
    public GameObject[] clouds;

    public GameObject End;

    public Vector2 CloudSpawn;
    public float Cloud_y;
    public int Randomindex;

    static int CloudNumber = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Randomindex = Random.Range(-1, clouds.Length);
        Spawn_cloud();
        InvokeRepeating("Spawn_cloud", 0, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn_cloud()
    {
        Randomindex = Random.Range(0, clouds.Length);
        Cloud_y = Random.Range(-5f, 2.25f);
        CloudSpawn = new Vector2(transform.position.x, transform.position.y + Cloud_y);

        GameObject cloud = Instantiate(clouds[Randomindex], CloudSpawn, Quaternion.identity);
        CloudNumber++;
    }
}
