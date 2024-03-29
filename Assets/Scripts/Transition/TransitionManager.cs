using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    [SceneName] public string startScene;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;
    private bool isFade;
    private bool canTransition;

    private void Start()
    {
        StartCoroutine(TransitionToScene(string.Empty, startScene));
    }

    private void OnEnabele()
    {
        EventHandler.GameStateChangeEvent += OnGameStateChangeEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameStateChangeEvent -= OnGameStateChangeEvent;
    }

    private void OnGameStateChangeEvent(GameState gameState)
    {
        canTransition = gameState == GameState.GamePlay;
    }

    public void Transition (string from,string to)
    {
        if (!isFade && canTransition)
        StartCoroutine(TransitionToScene(from,to));
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1);
        if (from != string.Empty)
        {
            EventHandler.CallBeforeSceneUnloadEvent();
            yield return SceneManager.UnloadSceneAsync(from);
        }
        
        yield return SceneManager.LoadSceneAsync(to,LoadSceneMode.Additive);

        //Set new Scene as the Active Scene
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        EventHandler.CallAfterSceneUnloadEvent();
        yield return Fade(0);
    }

    /// <summary>
    /// Fade Scene
    /// </summary>
    /// <param name="targetAlpha">1 is black, 0 is transparent</param>
    /// <returns></returns>
    private IEnumerator Fade(float targetAlpha)
    {
        isFade= true;

        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;

            fadeCanvasGroup.blocksRaycasts = false;

            isFade = false;
        }
    }
}

