using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject end;

    public float camera_x;
    public float camera_y;
    void Start()
    {
        camera_y = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
        end = GameObject.FindGameObjectWithTag("end");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
