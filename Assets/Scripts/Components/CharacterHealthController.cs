using System.Collections;
using UnityEngine;

namespace Components
{
    public class CharacterHealthController : MonoBehaviour, IDamage
    {
        [SerializeField] private int _health;
        [SerializeField] private bool _isImmortal;
        [SerializeField] private float _immortalDuration;

        public void TakeDamage(int damage)
        {
            if(_isImmortal)
                return;

            _health -= damage;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                StartImmortalStatus(); // Запуск неуязвимости после получения урона
            }

        }
        
        // Метод для активации неуязвимости
        private void StartImmortalStatus()
        {
            _isImmortal = true; // Устанавливаем флаг неуязвимости
            // Запускаем корутину, которая отключит неуязвимость через заданное время
            StartCoroutine(EndImmortalStatus());
        }

        // Корутин для окончания статуса неуязвимости
        private IEnumerator EndImmortalStatus()
        {
            yield return new WaitForSeconds(_immortalDuration); // Ждем, пока не закончится время
            _isImmortal = false; // Сбрасываем флаг неуязвимости
        }
    }
}