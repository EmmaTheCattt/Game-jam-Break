using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Script : MonoBehaviour
{

    public Collider2D col;
    public Animator Box_ani;

    public bool click;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        Box_ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            Box_ani.SetBool("Click", click);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            click = true;
            Debug.Log("Box Hit!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            click = false;
            Debug.Log("Box exit!");
        }
    }
}
