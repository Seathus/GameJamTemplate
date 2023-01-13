using UnityEngine;

namespace UnityTemplateProjects
{
    public class ReturnToTitleScreen : MonoBehaviour
    {
        public void Advance()
        {
            GameStateManager.Instance.SwitchToMainMenu();
            Destroy(GameStateManager.Instance.gameObject);
            Destroy(Loader.Instance.gameObject);
        }
    }
}