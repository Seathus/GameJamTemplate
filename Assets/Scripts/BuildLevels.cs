using System.Collections.Generic;
using UnityEngine;

namespace UnityTemplateProjects
{
    [CreateAssetMenu(fileName = "BuildLevels", menuName = "Levels/Build Levels", order = 0)]
    public class BuildLevels : ScriptableObject
    {
        public List<LevelDefinition> Levels;

        public LevelDefinition GetNextLevel(int currentLevelIndex)
        {
            return Levels[currentLevelIndex + 1];
        }

        public LevelDefinition GetFirstLevel()
        {
            return Levels[0];
        }
    }
}