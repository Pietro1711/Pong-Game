﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menü : MonoBehaviour {

    public Button Spielen_Button;
    public Button Verlassen_Button;
    


    public void Spiel_Spielen()
    {
        //SceneManager.LoadScene(1);
        NvpEventController.InvokeEvent(NvpGameEvents.OnGameStarted, this, null);
    }
       

    public void Spiel_Verlassen()
    {
        Application.Quit();
    }

    public void Nochmal_Spielen()
    {
        NvpEventController.InvokeEvent(NvpGameEvents.OnPlayAgain, this, null);
    }
}
