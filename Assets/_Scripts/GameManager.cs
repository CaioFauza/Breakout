using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
   private static GameManager _instance;
   
   public enum GameState { MENU, START, GAME, PAUSE, END };
   public GameState gameState { get; private set; }
   public delegate void ChangeStateDelegate();
   public static ChangeStateDelegate changeStateDelegate;

   public int lifes;
   public int points;
   public int powerUps;
   public bool powerUpUsed;

   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }
       return _instance;
   }

   private GameManager()
   {
       lifes = 3;
       points = 0;
       powerUps = 0;
       powerUpUsed = false;
       gameState = GameState.MENU;
   }

   public void ChangeState(GameState nextState)
   {
       if(nextState == GameState.GAME) Reset();
       gameState = nextState;
       changeStateDelegate();
   }

   private void Reset()
   {
       lifes = 3;
       points = 0;
       powerUps = 0;
       powerUpUsed = false;
   }

}