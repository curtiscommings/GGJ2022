using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    private GameObject dialogBox;
    [TextArea(3, 50)]
    public string fullText;
    private string[] elements;
    int curIndx = 0;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox =  GameObject.Find("dialogBox");
        elements = fullText.Split(System.Environment.NewLine.ToCharArray());
    }

    public void AdvanceText()
    {
        if (curIndx == elements.Length)
        {
            // dialog is over
            curIndx = 0; // reset in case reused
            dialogBox.GetComponent<Text>().text = "";
        }
        else
        {
            dialogBox.GetComponent<Text>().text = elements[curIndx];
            curIndx++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
