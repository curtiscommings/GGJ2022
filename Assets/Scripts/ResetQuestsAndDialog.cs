using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetQuestsAndDialog : MonoBehaviour
{
    [SerializeField] private List<Quest> _questList = new List<Quest>();
    [SerializeField] private List<Dialog> _dialogList = new List<Dialog>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnApplicationQuit()
    {
        foreach (var quest in _questList)
        {
            quest.ResetQuest();
        }

        foreach (var dialog in _dialogList)
        {
            dialog.Reset();
        }
    }
}
