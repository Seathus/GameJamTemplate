using UnityEngine;
using UnityEngine.UI;

namespace UnityTemplateProjects.UserInterface
{
    public class UI_GenericWindow : UI_Window
    {
        [SerializeField] private Button m_backButton;
        
        public override void Tick(float deltaTime)
        {
            
        }

        public override void Enter()
        {
            m_backButton.onClick.AddListener(() =>
            {
                UI_WindowStack.Instance.Pop(true);
            });
        }

        public override void Suspend()
        {
            
        }

        public override void Resume()
        {
            
        }

        public override void OnExitedWindow()
        {
            m_backButton.onClick.RemoveAllListeners();
        }
    }
}