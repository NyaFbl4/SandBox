using UnityEngine;

namespace Components
{
    public class LvlComponent : MonoBehaviour
    {
        [SerializeField] private int _currentLevel;
        [SerializeField] private int _currentExperience;
        [SerializeField] private int _experienceToNextLevel = 100;

        private void Start()
        {
            _currentLevel = 0;
            _currentExperience = 0;
        }

        public void UpdateExperience(int exp)
        {
            _currentExperience += exp;

            // Проверка на уровень
            while (_currentExperience >= _experienceToNextLevel)
            {
                _currentExperience -= _currentExperience;
                LevelUp();
            }
        }
        
        private void LevelUp()
        {
            _currentLevel++;
            _experienceToNextLevel = CalculateExperienceToNextLevel(_currentLevel);
        }
        
        private int CalculateExperienceToNextLevel(int level)
        {
            return 100 + (level - 1) * 50;
        }
    }
}