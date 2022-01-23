using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmPro;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMessage(string i_message)
    {
        _tmPro.text = i_message;
    }

    public void ShowMessage(DialogMessage i_message)
    {
        _tmPro.text = i_message._content;
    }

    public void ClearTextBox()
    {
        _tmPro.text = "";
    }

}
