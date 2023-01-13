using UnityEngine;

namespace UnityTemplateProjects
{
    [CreateAssetMenu(fileName = "Level Def", menuName = "Levels/Level Definition", order = 0)]
    public class LevelDefinition : ScriptableObject
    {
        public string SceneName;
    }
}