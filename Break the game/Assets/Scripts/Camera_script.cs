using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject end;
    public GameObject Butt;

    public Vector3 Camera_pos;

    public float camera_x;
    public float camera_y;
    public float offset = 5;
    public float offset_y = 2;

    public float Camera_new_x;
    public float Camera_new_y;
    void Start()
    {
        camera_y = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
        end = GameObject.FindGameObjectWithTag("end");
        Butt = GameObject.FindGameObjectWithTag("Buttsex");
    }

    // Update is called once per frame
    void Update()
    {
        //x
        if (player.transform.position.x <= end.transform.position.x + offset)
        {
            Camera_new_x = end.transform.position.x + offset;
            Camera_pos = new Vector3(end.transform.position.x + offset, camera_y, -1);
        }
        else
        {
            Camera_new_x = player.transform.position.x;
            Camera_pos = new Vector3(player.transform.position.x, camera_y, -1);
        }

        //y
        if (player.transform.position.y <= Butt.transform.position.y + offset_y)
        {
            Camera_new_y = camera_y;
        }
        else
        {
            Camera_new_y = player.transform.position.y;
        }

        Camera_pos = new Vector3(Camera_new_x, Camera_new_y, -1);
        transform.position = Camera_pos;
    }
}
