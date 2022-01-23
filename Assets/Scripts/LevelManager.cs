using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using ScriptableObjectArchitecture;

public class LevelManager : MonoBehaviour
{
    private Scene _loadedInteractionScene;
    [SerializeField] private GameEvent _startSceneLoadEvent;
    [SerializeField] private GameEvent _onSceneLoadedEvent;

    // Start is called before the first frame update
    void Start()
    {

    }

    private IEnumerator InitiateSceneLoad(string i_sceneToLoad)
    {
        _startSceneLoadEvent.Raise();
        yield return new WaitForSeconds(1);
        var sceneToLoad = SceneManager.GetSceneByName(i_sceneToLoad);

        //if (_loadedInteractionScene != null)
        //yield return SceneManager.UnloadSceneAsync(_loadedInteractionScene);

        yield return SceneManager.LoadSceneAsync(i_sceneToLoad);
        _loadedInteractionScene = sceneToLoad;

        _onSceneLoadedEvent.Raise();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string i_sceneToLoad)
    {
        StartCoroutine(InitiateSceneLoad(i_sceneToLoad));
    }
}
