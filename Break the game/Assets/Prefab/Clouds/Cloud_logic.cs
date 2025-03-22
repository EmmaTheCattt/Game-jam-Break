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
    public float time = 0;
    void Start()
    {
        Cloud_transform = GetComponent<Transform>();
        speed = Random.Range(-1f, -2f);
        size = Random.Range(-0.25f, 0.25f);
        Cloud_transform.localScale = new Vector2(1 + size, 1 + size);

        movement = new Vector3(speed, 0, 0);
        Invoke("Clouds_death", 20f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movement * Time.deltaTime;
    }

    private void Clouds_death()
    {
        Destroy(gameObject);
    }
}
