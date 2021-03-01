﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void StartGame()
    {
        gm.ChangeState(GameManager.GameState.START);
    }
}
