using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // +++ Life Cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        Debug.Log("StartCalled");
        NvpEventController.SubscribeToEvent(NvpGameEvents.OnMainStarted, OnMainStarted);
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

    }
}
