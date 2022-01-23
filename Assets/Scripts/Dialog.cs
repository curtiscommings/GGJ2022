using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogMessage
{
    public string _speaker;
    public string _content;
    public bool _isPrompt;
    public GameObject _promptPrefab;

    public DialogMessage(string speaker, string content)
    {
        _speaker = speaker;
        _content = content;
    }

    public static DialogMessage Empty = new DialogMessage("", "");
}

[CreateAssetMenu(fileName = "Dialog")]
public class Dialog : ScriptableObject
{
    private GameObject dialogBox;
    public List<DialogMessage> elements;
    public int curIndx = 0;
    // Start is called before the first frame update
    public DialogMessage AdvanceText()
    {
        Debug.Log(curIndx);

        if (curIndx == elements.Count)
        {
            // dialog is over
            curIndx = 0; // reset in case reused
            return DialogMessage.Empty;
        }
        else
        {
            var curMessage = elements[curIndx];
            curIndx++;
            return curMessage;
        }
    }

    public void Reset()
    {
        curIndx = 0;
    }
}
