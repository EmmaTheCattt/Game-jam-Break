using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public string[] Starting_lines;
    public float textspeed;

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        Text.text = string.Empty;
        start_dia();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Text.text == Starting_lines[index])
            {
                next_line();
            }
            else
            {
                StopAllCoroutines();
                Text.text = Starting_lines[index];
            }
        }
    }

    void start_dia()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in Starting_lines[index].ToCharArray())
        {
            Text.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void next_line()
    {
        if (index < Starting_lines.Length - 1)
        {
            index++;
            Text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Invoke("Next_scene", 2f);
        }
    }

    void Next_scene()
    {
        SceneManager.LoadScene("Level1");
    }
}
