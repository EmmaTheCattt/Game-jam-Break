using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject end;

    public Vector3 Camera_pos;

    public float camera_x;
    public float camera_y;
    public float offset = 5;
    void Start()
    {
        camera_y = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
        end = GameObject.FindGameObjectWithTag("end");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x <= end.transform.position.x + offset)
        {
            Camera_pos = new Vector3(end.transform.position.x + offset, camera_y, -1);
        }
        else
        {
            Camera_pos = new Vector3(player.transform.position.x, camera_y, -1);
        }
        
        transform.position = Camera_pos;
    }
}
