using System;
using System.Collections;
using UnityEngine;

namespace UnityTemplateProjects.UserInterface
{
    public class UI_Start : MonoBehaviour
    {
        [SerializeField] private UI_MainMenuWindow m_mainMenuWindow;

        private void Start()
        {
            UI_WindowStack.Instance.Push(m_mainMenuWindow);
        }
    }
}