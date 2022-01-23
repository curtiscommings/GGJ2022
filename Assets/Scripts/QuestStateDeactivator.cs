using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStateDeactivator : MonoBehaviour
{
    [SerializeField] private Quest _quest;
    [SerializeField] private Quest.State _state;
    // Start is called before the first frame update
    void Start()
    {
        if (_quest.questProgress != _state)
        {
            Destroy(gameObject);
        }
    }
}
