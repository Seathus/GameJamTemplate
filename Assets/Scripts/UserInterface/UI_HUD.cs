using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityTemplateProjects.UserInterface
{
    public class UI_HUD : MonoBehaviour
    {
        [SerializeField] private UI_GenericWindow m_genericWindow;
        [SerializeField] private Button m_randomButton;

        private void Start()
        {
            m_randomButton.onClick.AddListener(() =>
            {
                UI_WindowStack.Instance.Push(m_genericWindow);    
            });
        }
    }
}