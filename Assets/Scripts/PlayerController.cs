using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private CharacterController _cController;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private GameEvent _interactionEventChannel;
    [SerializeField] private TextMeshPro _myTMP;
    [SerializeField] private QuestList _playerQuestList;

    private bool _canMove = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var input = Input.GetAxis("Horizontal");
        var movementDir = new Vector3(input, 0, 0);

        _cController.Move(movementDir * _movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Interact();
        }



    }

    private void Interact()
    {
        Debug.Log("doink");

        _interactionEventChannel.Raise();
    }

    public void RestrictMovement()
    {
        _canMove = false;
    }

    public void RestoreMovement()
    {
        _canMove = true;
    }
}
