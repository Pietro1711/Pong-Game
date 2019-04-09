using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // +++ Life Cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        Debug.Log("StartCalled");
        NvpEventController.SubscribeToEvent(NvpGameEvents.OnMainStarted, OnMainStarted);
        NvpEventController.SubscribeToEvent(NvpGameEvents.OnGameStarted, OnGameStarted);
        NvpEventController.SubscribeToEvent(NvpGameEvents.OnPlayerOneWins, OnPlayerOneWins);
        NvpEventController.SubscribeToEvent(NvpGameEvents.OnPlayAgain, OnPlayAgain);
    }


    void OnDisable()
    {
        Debug.Log("DisableCalled");
        NvpEventController.UnsubscribeFromEvent(NvpGameEvents.OnMainStarted, OnMainStarted);
    }


    // +++ Event Handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnMainStarted(object sender, object eventargs)
    {
        Debug.Log("OnMainStart");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        
    }

    private void OnGameStarted(object sender, object eventargs)
    {
        Debug.Log("OnGameStarted");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(0);
    }

    private void OnPlayerOneWins(object sender, object eventargs)
    {
        Debug.Log("OnPlayer1Wins");
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(1);
    }

    private void OnPlayerTwoWins(object sender, object eventargs)
    {
        Debug.Log("OnPlayerTwoWins");
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(1);
    }
    
    private void OnPlayAgain(object sender, object eventargs)
    {
        Debug.Log("OnPlayAgain");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(2);
        SceneManager.UnloadSceneAsync(3);
    }

}
