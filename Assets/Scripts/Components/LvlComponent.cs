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
            while (_currentExperience >= _currentExperience)
            {
                _currentExperience -= _currentExperience;
                LevelUp();
            }
        }
        
        private void LevelUp()
        {
            _currentLevel++;
            _experienceToNextLevel = CalculateExperienceToNextLevel(_currentLevel);
            Debug.Log($"Поздравляем! Вы достигли уровня {_currentLevel}!");
        }
        
        private int CalculateExperienceToNextLevel(int level)
        {
            // Вы можете использовать любую формулу для расчета необходимого опыта для следующего уровня.
            // Пример: добавление 50 опыта за каждый уровень.
            return 100 + (level - 1) * 50;
        }
    }
}