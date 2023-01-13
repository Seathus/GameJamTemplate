using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    public enum GameState
    {
        TITLESCREEN,
        PLAY
    }

    public Action<GameState> StateUpdated;

    public void SwitchToMainMenu()
    {
        UpdateState(GameState.TITLESCREEN);
    }

    public void StartGame()
    {
        UpdateState(GameState.PLAY);
    }

    private GameState m_state;
    
    private void UpdateState(GameState newState)
    {
        m_state = newState;
        
        StateUpdated?.Invoke(newState);
    }
    
    protected override void Awake()
    {
        base.Awake();
            
        DontDestroyOnLoad(this.gameObject);
    }
}
