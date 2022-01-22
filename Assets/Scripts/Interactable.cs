using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Dialog _dialog;
    [SerializeField] private GameEventBase<string> _textEvent;

    private bool _canUse = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract()
    {
        if (_canUse)
            _textEvent.Raise(_dialog.AdvanceText());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _canUse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _canUse = false;
        }
    }
}
