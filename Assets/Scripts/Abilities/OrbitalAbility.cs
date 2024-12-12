using System.Collections;
using Assets.Scripts.Bullet;
using UnityEngine;

namespace Components
{
    public class OrbitalAbility : MonoBehaviour, ILvlUp
    {
        [Header("Префаб шарика, который будет вращаться")]
        [SerializeField] private GameObject _orbPrefab; // Префаб шарика
        [Header("Время между активациями способности")]
        [SerializeField] private float _cooldown = 10f; // Время между активациями способности
        [Header("Количество шариков, которые будут созданы")]
        [SerializeField] private int _orbCount = 5; // Количество шариков
        [Header("Радиус, на котором будут располагаться шарики")]
        [SerializeField] private float _radius = 2f; // Радиус вращения
        [Header("Скорость вращения шаров")]
        [SerializeField] private float _rotationSpeed;
        [Header("Длительность способности в секундах")]
        [SerializeField] private float _duration = 5f; // Длительность в секундах
        [Header("Урон от одного шарика")]
        [SerializeField] private int _damage = 10;

        [SerializeField] private bool _isActiv;
        private GameObject[] _orbs; // Для хранения шариков

        void Start()
        {
            _isActiv = false;

            StartCoroutine(AbilityCooldown());
        }

        public void LvlUp()
        {
            
        }

        private IEnumerator AbilityCooldown()
        {
            //if (!_isActiv)
            //{
                //while (true) // Бесконечный цикл для регулярной активации способности
                //{
                    yield return new WaitForSeconds(_cooldown); // Ждем cooldown перед активацией
                    ActivateAbility(); // Активируем способность
                //}
            //}
        }
        
        private void ActivateAbility()
        {
            StartCoroutine(SpawnAndRotateOrbs());
            _isActiv = true;
        }

        private IEnumerator SpawnAndRotateOrbs()
        {
            _orbs = new GameObject[_orbCount];

            // Создание и позиционирование шариков
            for (int i = 0; i < _orbCount; i++)
            {
                float angle = i * (360f / _orbCount);
                Vector3 orbPosition = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0.5f, Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
                 _orbs[i] = Instantiate(_orbPrefab, transform.position + orbPosition, Quaternion.identity);

                OrbitalAbilityBullet orbitalAbilityComponent = _orbs[i].gameObject.GetComponent<OrbitalAbilityBullet>();

                if (_orbs[i] != null)
                {
                    orbitalAbilityComponent.SetDamage(_damage);
                }
            }

            // Вращение шариков
            float elapsedTime = 0f;
            while (elapsedTime < _duration)
            {
                for (int i = 0; i < _orbCount; i++)
                {
                    float angle = i * (360f / _orbCount) + (elapsedTime / _duration * _rotationSpeed * 360f);
                    //float angle = i * (360f / _orbCount) + (elapsedTime / _duration) * 360f;
                    
                    Vector3 orbPosition = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0.5f, Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
                    _orbs[i].transform.position = transform.position + orbPosition;
                }

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Удаление шариков после завершения способности
            for (int i = 0; i < _orbCount; i++)
            {
                Destroy(_orbs[i]);
            }

            _isActiv = false;
            StartCoroutine(AbilityCooldown());
        }
    }
}