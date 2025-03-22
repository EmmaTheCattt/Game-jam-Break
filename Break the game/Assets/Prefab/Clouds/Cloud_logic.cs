using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Cloud_logic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject end;

    public Vector3 movement;
    public Transform Cloud_transform;
    public float speed;
    public float size;
    public float time = 0;
    public float alpha = 1;
    public Color C;

    public GameObject Cloud;
    public SpriteRenderer SR;
    void Start()
    {
        Cloud = this.gameObject;
        SR = Cloud.GetComponent<SpriteRenderer>();
        Color C = SR.material.color;
        Cloud_transform = GetComponent<Transform>();
        speed = Random.Range(-0.5f, -1.5f);
        size = Random.Range(-0.25f, 0.25f);
        Cloud_transform.localScale = new Vector2(1 + size, 1 + size);

        movement = new Vector3(speed, 0, 0);
        Invoke("Clouds_death", 20f);

        end = GameObject.FindGameObjectWithTag("end");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movement * Time.deltaTime;
        C.a = alpha;
        SR.material.color = C;

        if (transform.position.x < end.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    private void Clouds_death()
    {
        InvokeRepeating("fade", 0.05f, 0.05f);
        if (alpha < 0)
        {
            Destroy(gameObject);
        }
    }

    private void fade()
    {
        alpha -= 0.01f;
    }

    private void Fast_fade()
    {
        alpha -= 0.025f;
        Clouds_death();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            InvokeRepeating("Fast_fade", 0.05f, 0.05f);
        }
    }
}
