using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace UnityTemplateProjects.UserInterface
{
    public abstract class UI_Window : MonoBehaviour
    {
        public Action<UI_Window> RequestPush;
        public Action<UI_Window> RequestSet;
        public Action RequestPop;
        
        public abstract void Tick(float deltaTime);
        public abstract void Enter();
        public abstract void Suspend();
        public abstract void Resume();
        public abstract void OnExitedWindow();
        
        public void RequestCloseWindow()
        {
            Assert.IsTrue(UI_WindowStack.Instance, "There is no window stack instance.");
            
            RequestPop?.Invoke();
        }

        protected void RequestNewWindow(UI_Window newWindow)
        {
            Assert.IsTrue(UI_WindowStack.Instance, "There is no window stack instance.");
            
            RequestPush?.Invoke(newWindow);
        }

        /// <summary>
        /// closes any window above target window.
        /// target window must already exist in the stack.
        /// </summary>
        protected void SwitchToWindow(UI_Window targetWindow)
        {
            Assert.IsTrue(UI_WindowStack.Instance, "There is no window stack instance.");
            
            RequestSet?.Invoke(targetWindow);
        }
    }
}