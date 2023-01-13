using UnityEngine;
using UnityEngine.UI;

namespace UnityTemplateProjects.UserInterface
{
    public class UI_MainMenuWindow : UI_Window
    {
        [SerializeField] private UI_CreditsWindow m_creditsWindow;
        [SerializeField] private Button m_playButton;
        [SerializeField] private Button m_creditsButton;
        [SerializeField] private Button m_quitButton;
        
        public override void Tick(float deltaTime)
        {
            
        }

        public override void Enter()
        {
            m_creditsButton.onClick.AddListener(() =>
            {
                UI_WindowStack.Instance.Push(m_creditsWindow);    
            });
            
            m_playButton.onClick.AddListener(() =>
            {
                GameStateManager.Instance.StartGame();
            });
            
            m_quitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }

        public override void Suspend()
        {
            gameObject.SetActive(false);
            m_creditsButton.onClick.RemoveAllListeners();
            m_playButton.onClick.RemoveAllListeners();
        }

        public override void Resume()
        {
            gameObject.SetActive(true);
            m_creditsButton.onClick.AddListener(() =>
            {
                UI_WindowStack.Instance.Push(m_creditsWindow);    
            });
            m_playButton.onClick.AddListener(() =>
            {
                GameStateManager.Instance.StartGame();
            });
        }

        public override void OnExitedWindow()
        {
            m_creditsButton.onClick.RemoveAllListeners();
            m_playButton.onClick.RemoveAllListeners();
        }
    }
}