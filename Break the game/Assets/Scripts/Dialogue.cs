using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
}
