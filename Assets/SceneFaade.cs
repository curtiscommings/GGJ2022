using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneFaade : MonoBehaviour
{
    [SerializeField] private float _fadeTime;
    [SerializeField] private Image _fadeImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator FadeOut()
    {
        float i = 0;

        while (i < _fadeTime)
        {
            _fadeImage.color = Color.Lerp(Color.clear, Color.black, i / _fadeTime);
            i += Time.deltaTime;

            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float i = 0;

        while (i < _fadeTime)
        {
            _fadeImage.color = Color.Lerp(Color.black, Color.clear, i / _fadeTime);
            i += Time.deltaTime;

            yield return null;

        }
    }

    public void FadeSceneOut()
    {
        StartCoroutine(FadeOut());
    }


    public void FadeSceneIn()
    {
        StartCoroutine(FadeIn());

    }
}
