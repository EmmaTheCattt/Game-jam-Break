using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_logic : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 movement;
    public Transform Cloud_transform;
    public float speed;
    public float size;
    public float Death_time = 15;
    public float time = 0;
    void Start()
    {
        Cloud_transform = GetComponent<Transform>();
        speed = Random.Range(-1f, -3f);
        size = Random.Range(-0.1f, 0.1f);
        Cloud_transform.localScale = new Vector2(1 + size, 1 + size);

        movement = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time =+ Time.time;
        transform.position += movement * Time.deltaTime;

        if (time > Death_time)
        {
            Destroy(gameObject);
        }
    }
}
