using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "Quest")]
public class Quest : ScriptableObject
{
    public enum State
    {
        NOT_READY,
        READY,
        ACCEPTED,
        TURN_IN,
        COMPLETED
    };

    public State questProgress = State.NOT_READY;

    public string Name;
    [TextArea(20, 50)]
    public string Description;

    public Dialog questStartDialog;
    public Dialog questInProgressDialog;
    public Dialog finishQuestDialong;

    public void OnMakeQuestReady()
    {
        questProgress = State.READY;
    }

    public void OnAcceptQuest()
    {
        if (questProgress == State.READY)
            questProgress = State.ACCEPTED;
    }

    public void OnTurnInQuest()
    {
        if (questProgress == State.ACCEPTED)
            questProgress = State.TURN_IN;
    }

    public void OnCompleteQuest()
    {
        if (questProgress == State.TURN_IN)
            questProgress = State.COMPLETED;
    }

    public void ResetQuest()
    {
        questProgress = State.READY;
    }
}

[CreateAssetMenu(fileName = "QuestList")]
public class QuestList : ScriptableObject
{
    public List<Quest> data;
}
