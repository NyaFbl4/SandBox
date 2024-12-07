using System.Collections;
using UnityEngine;

namespace Components
{
    public class OrbitalAbility : MonoBehaviour
    {
        [SerializeField] private GameObject _orbPrefab; // Префаб шарика
        [SerializeField] private int _orbCount = 5; // Количество шариков
        [SerializeField] private float _radius = 2f; // Радиус вращения
        [SerializeField] private float _duration = 5f; // Длительность в секундах

        private GameObject[] _orbs; // Для хранения шариков

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Например, по нажатию пробела
            {
                ActivateAbility();
            }
        }
        
        public void ActivateAbility()
        {
            StartCoroutine(SpawnAndRotateOrbs());
        }

        private IEnumerator SpawnAndRotateOrbs()
        {
            _orbs = new GameObject[_orbCount];

            // Создание и позиционирование шариков
            for (int i = 0; i < _orbCount; i++)
            {
                float angle = i * (360f / _orbCount);
                Vector3 orbPosition = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
                _orbs[i] = Instantiate(_orbPrefab, transform.position + orbPosition, Quaternion.identity);
            }

            // Вращение шариков
            float elapsedTime = 0f;
            while (elapsedTime < _duration)
            {
                for (int i = 0; i < _orbCount; i++)
                {
                    float angle = i * (360f / _orbCount) + (elapsedTime / _duration) * 360f;
                    Vector3 orbPosition = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
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
        }
    }
}