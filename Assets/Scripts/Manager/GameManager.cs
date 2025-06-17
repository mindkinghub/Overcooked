using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event EventHandler OnGameStateChanged;
    private enum Gamestate
    {
        WaitingToStart,
        CountDownToStart,
        Playing,
        GameOver
    }

    private Gamestate gamestate;
    [SerializeField] private Player player;
    private float waitingToStartTimer = 1;
    private float countDownToStartTimer = 3;
    private float gamePlayTimer = 60;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Initialize the game state
        TurnToWaitingToStart();
    }

    void Update()
    {
        switch (gamestate)
        {
            case Gamestate.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer <= 0)
                {
                    TurnToCountDownToStart();
                }
                break;
            case Gamestate.CountDownToStart:
                countDownToStartTimer -= Time.deltaTime;
                if (countDownToStartTimer <= 0)
                {
                    TurnToGamePlaying();
                }
                break;
            case Gamestate.Playing:
                gamePlayTimer -= Time.deltaTime;
                if (gamePlayTimer <= 0)
                {
                    TurnToGameOver();
                }
                break;
            case Gamestate.GameOver:
                break;
        }
    }

    private void TurnToWaitingToStart()
    {
        gamestate = Gamestate.WaitingToStart;
        DisablePlayer();
        OnGameStateChanged?.Invoke(this, EventArgs.Empty);
    }
    private void TurnToCountDownToStart()
    {
        gamestate = Gamestate.CountDownToStart;
        DisablePlayer();
        OnGameStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void TurnToGamePlaying()
    {
        gamestate = Gamestate.Playing;
        EnablePlayer();
        OnGameStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void TurnToGameOver()
    {
        gamestate = Gamestate.GameOver;
        DisablePlayer();
        OnGameStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void DisablePlayer()
    {
        player.enabled = false;
    }

    private void EnablePlayer()
    {
        player.enabled = true;
    }

    public bool IsCountDownState()
    {
        return gamestate == Gamestate.CountDownToStart;
    }

    public bool IsGamePlayingState()
    {
        return gamestate == Gamestate.Playing;
    }

    public bool IsGameOverState()
    {
        return gamestate == Gamestate.GameOver;
    }
    public float GetCountDownToStartTimer()
    {
        return countDownToStartTimer;
    }
}
