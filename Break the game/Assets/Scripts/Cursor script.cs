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

    public Vector2 CursorPos;

    public ParticleSystem Par;
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
        Par.enableEmission = false;

        if (Input.GetMouseButtonDown(0))
        {
            Par.enableEmission = true;
        }
    }
    private void Position_cursor()
    {
        Mouse_x = Input.mousePosition.x;
        Mouse_y = Input.mousePosition.y;

        CursorPos = new Vector2(Mouse_x, Mouse_y);
        CursorPos = Camera.main.ScreenToWorldPoint(CursorPos);
    }
}
