using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager _instance;

    public enum GameState { MENU, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }

    public int points;
    public int lives;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
          _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        points = 0;
        lives = 10;
        gameState = GameState.MENU;
    }

    private void Reset()
    {
        lives = 10;
        points = 0;
    }

    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.GAME) Reset();

        gameState = nextState;
        changeStateDelegate();
    }
}
