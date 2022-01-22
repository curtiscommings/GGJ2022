using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialog")]
public class Dialog : ScriptableObject
{
    private GameObject dialogBox;
    [TextArea(3, 50)]
    public string fullText;
    private string[] elements;
    int curIndx = 0;
    // Start is called before the first frame update
    public string AdvanceText()
    {
        if (elements.Length == 0)
            elements = fullText.Split(System.Environment.NewLine.ToCharArray());

        if (curIndx == elements.Length)
        {
            // dialog is over
            curIndx = 0; // reset in case reused
            return "";
        }
        else
        {
            var message = elements[curIndx];
            curIndx++;
            return message;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
