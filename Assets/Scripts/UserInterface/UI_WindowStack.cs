using System.Collections.Generic;
using UnityEngine;

namespace UnityTemplateProjects.UserInterface
{
    public class UI_WindowStack : Singleton<UI_WindowStack>
    {
        [SerializeField] private Transform m_windowStackContainer;
        public UI_Window CurrentWindow => m_windowStack.Peek();
        
        /// <summary>
        /// Sets new window as main window, with the option to set existing spawned window
        /// </summary>
        /// <param name="screenPrefabToPush">window to add</param>
        /// <param name="toInstantiate">instantiate window requested</param>
        public void Push(UI_Window screenPrefabToPush, bool toInstantiate = true)
        {
            SuspendCurrentWindow();    

            UI_Window instance = toInstantiate ? Instantiate(screenPrefabToPush, m_windowStackContainer) : screenPrefabToPush;
            
            SetupNewWindow(instance);
        }
        
        /// <summary>
        /// Sets new window as main window. 
        /// </summary>
        /// <param name="screenPrefabToPush">window to add</param>
        /// <param name="toInstantiate">instantiate window requested</param>
        public void Push(UI_Window screenPrefabToPush)
        {
            SuspendCurrentWindow();    

            UI_Window instance = Instantiate(screenPrefabToPush, m_windowStackContainer);
            
            SetupNewWindow(instance);
        }
        
        /// <summary>
        /// Sets new window as main window. 
        /// </summary>
        /// <param name="screenPrefabToPush">window to add</param>
        /// <param name="toInstantiate">instantiate window requested</param>
        public void Push(UI_Window screenPrefabToPush, Transform customContainer)
        {
            SuspendCurrentWindow();    

            UI_Window instance = Instantiate(screenPrefabToPush, customContainer);
            
            SetupNewWindow(instance);
        }
        
        /// <summary>
        /// Removes the top window from the stack with option to not destroy removed window. next window below will become target
        /// unless there are no more windows left
        /// </summary>
        public void Pop(bool destroyWindow)
        {
            CloseTopWindow(destroyWindow);

            if (m_windowStack.Count > 0)
            {
                CurrentWindow.Resume();
            }
        }
        
        // ----------------------------------------------------- protected
        
        protected override void Awake()
        {
            base.Awake();
            //here are references to the gameplay classes and subscribing to their events to update the UI
            m_windowStack = new Stack<UI_Window>();
            m_canvas = GetComponent<Canvas>();
        }

        // ----------------------------------------------------- private
        
        private Stack<UI_Window> m_windowStack;
        private Canvas m_canvas;

        private void Update()
        {
            if (m_windowStack.Count > 0)
            {
                CurrentWindow.Tick(Time.deltaTime);
            }
        }
        
        /// <summary>
        /// Removes AND destroys the top window from the stack. next window below will become target
        /// unless there are no more windows left
        /// </summary>
        private void Pop()
        {
            if (m_windowStack.Count > 0)
            {
                CurrentWindow.Resume();
            }
        }
        
        private void SuspendCurrentWindow()
        {
            if (m_windowStack.Count > 0)
            {
                CurrentWindow.Suspend();
            }
        }
        
        private void SetupNewWindow(UI_Window window)
        {
            window.RequestPush += Push;
            window.RequestPop += Pop;
            m_windowStack.Push(window);
            window.Enter();
        }
        
        /// <summary>
        /// Includes window provided
        /// </summary>
        private void CloseTopWindow(bool destroyWindow = true)
        {
            var poppingScreen = m_windowStack.Pop();
            poppingScreen.OnExitedWindow();
                
            if (destroyWindow)
            {
                Destroy(poppingScreen.gameObject);    
            }
        }
    }
}