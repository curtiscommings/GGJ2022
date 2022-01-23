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
    [SerializeField] private GameEventBase<GameObject> _spawnPromptEvent;


    [SerializeField] private Quest _quest;

    private bool _canUse = false;
    private bool _waitingForInput = false;
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
                if (!_waitingForInput)
                {

                    Debug.Log("No quest here");
                    var message = _dialog.AdvanceText();
                    _textEvent.Raise(message._content);
                    _speakerTextEvent.Raise(message._speaker);
                    if (message._isPrompt)
                    {
                        _waitingForInput = true;
                        _spawnPromptEvent.Raise(message._promptPrefab);
                    }
                }
                else
                {
                    _onDialogEnd.Raise();
                    _canUse = false;
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
                _quest.OnCompleteQuest();
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
        else
        {
            _textEvent.Raise(message._content);
            _speakerTextEvent.Raise(message._speaker);
        }

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
