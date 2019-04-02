using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start ()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        NvpEventController.InvokeEvent(NvpGameEvents.OnMainStarted, this, 42);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
