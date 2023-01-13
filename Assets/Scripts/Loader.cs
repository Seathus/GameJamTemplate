using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTemplateProjects
{
    public class Loader : Singleton<Loader>
    {
        [SerializeField] private BuildLevels m_buildLevels;
        
        public void LoadNextLevel()
        {
            var nextLevel = m_buildLevels.GetNextLevel(m_currentLevel);
            
            m_currentLevel++;
            
            SceneManager.LoadScene(nextLevel.SceneName);
        }

        protected override void Awake()
        {
            base.Awake();
            
            DontDestroyOnLoad(this.gameObject);
            
            GameStateManager.Instance.StateUpdated += OnGameStateUpdated;
        }
        
        private int m_currentLevel;

        private void OnGameStateUpdated(GameStateManager.GameState newGameState)
        {
            switch (newGameState)
            {
                case GameStateManager.GameState.PLAY:
                    LoadNextLevel(); //only used when we want to start from the beginning
                    break;
                case GameStateManager.GameState.TITLESCREEN:
                    m_currentLevel = 0;
                    SceneManager.LoadScene("Titlescreen");
                    break;
            }
        }
    }
}