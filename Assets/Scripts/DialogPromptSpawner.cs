using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPromptSpawner : MonoBehaviour
{
    private GameObject _spawnedPrompt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPrompt(GameObject i_prompt)
    {
        _spawnedPrompt = GameObject.Instantiate(i_prompt, this.transform);
    }

    public void RemovePrompt()
    {
        Destroy(_spawnedPrompt);
    }
}
