using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Cursorscript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Mouse_x;
    public float Mouse_y;
    public bool Fade;

    public Vector2 CursorPos;

    public ParticleSystem Par;
    public ParticleSystemRenderer Rend;
    public Animator Anime;
    public Collider2D Cus_col;

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        Mouse_x = Input.mousePosition.x;
        Mouse_y = Input.mousePosition.y;

        CursorPos = new Vector2(Mouse_x, Mouse_y);
        CursorPos = Camera.main.ScreenToWorldPoint(CursorPos);
        transform.position = CursorPos;

    }

    private void Awake()
    {
        Par = GetComponentInChildren<ParticleSystem>();
        Rend = GetComponentInChildren<ParticleSystemRenderer>();
        Anime = GetComponentInChildren<Animator>();
        Cus_col = GetComponentInChildren<Collider2D>();
        Cus_col.enabled = false;
        Particles_mouse_off();
    }

    // Update is called once per frame
    void Update()
    {
        
        Position_cursor();
        On_click();
        transform.position = CursorPos;
    }

    private void On_click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Par.enableEmission = true;
            Cus_col.enabled = true;
            Invoke("Particles_mouse_off", 0.1f);
        }

        if (Input.GetMouseButton(0)) {
            Fade = true;
            Anime.SetBool("Down", Fade);
        }
        else
        {
            Fade = false;
            Cus_col.enabled = false;
            Anime.SetBool("Down", Fade);
        }
    }

    private void Particles_mouse_off()
    {
        Par.enableEmission = false;
    }
    private void Position_cursor()
    {
        Mouse_x = Input.mousePosition.x;
        Mouse_y = Input.mousePosition.y;

        CursorPos = new Vector2(Mouse_x, Mouse_y);
        CursorPos = Camera.main.ScreenToWorldPoint(CursorPos);
    }
}
