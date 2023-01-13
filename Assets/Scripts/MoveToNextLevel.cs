using UnityEngine;

namespace UnityTemplateProjects
{
    public class MoveToNextLevel : MonoBehaviour
    {
        public void Advance()
        {
            Loader.Instance.LoadNextLevel();
        }
    }
}