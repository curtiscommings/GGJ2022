using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Dialog _dialog;
    [SerializeField] private GameEventBase<string> _textEvent;
    [SerializeField] private GameEventBase<string> _speakerTextEvent;
    [SerializeField] private GameEvent _onDialogEnd;

    [SerializeField] private Quest _quest;

    private bool _canUse = false;
    private DialogMessage _lastMessage;
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
        {
            if (_quest != null)
                ProcessQuestDialog();
            else
            {
                if (_lastMessage._isPrompt)
                {

                }
                else
                {

                    var message = _dialog.AdvanceText();
                    _textEvent.Raise(message._content);
                    _speakerTextEvent.Raise(message._speaker);
                    _lastMessage = message;
                }
            }

        }
    }

    private void ProcessQuestDialog()
    {
        DialogMessage message;

        Debug.Log(_quest.questProgress);

        switch (_quest.questProgress)
        {
            case Quest.State.COMPLETED:
                message = _dialog.AdvanceText();
                break;
            case Quest.State.TURN_IN:
                message = _quest.finishQuestDialong.AdvanceText();
                break;
            case Quest.State.ACCEPTED:
                message = _quest.questInProgressDialog.AdvanceText();
                break;
            case Quest.State.READY:
                message = _quest.questStartDialog.AdvanceText();
                break;
            default:
                message = DialogMessage.Empty;
                break;
        }

        if (message._content == "")
        {
            _onDialogEnd.Raise();
            _canUse = false;
        }

        _textEvent.Raise(message._content);
        _speakerTextEvent.Raise(message._speaker);
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
