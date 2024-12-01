using System.Collections;
using Assets.Scripts.Bullet;
using UnityEngine;

namespace Components
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _bulletSpeed = 20f;
        [SerializeField] private int _bulletDamage = 5;
        
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Transform[] _shootPoints;
        
        [SerializeField] private float _detectionRadius = 10f;
        [SerializeField] private float _fireRate = 1f; // Интервал между выстрелами
        
        [SerializeField] private GameObject _target;
        
        private Coroutine _shootingCoroutine;

        private void Update()
        {
            _target = FindTarget();

            // Запускаем или останавливаем корутину в зависимости от наличия цели
            if (_target != null && _shootingCoroutine == null)
            {
                _shootingCoroutine = StartCoroutine(ShootAutomatically());
            }
            else if (_target == null && _shootingCoroutine != null)
            {
                StopCoroutine(_shootingCoroutine);
                _shootingCoroutine = null;
            }

            /*
            if (Input.GetKeyDown(KeyCode.Space)) // Проверяем нажатие пробела для стрельбы
            {
                Debug.Log("shoot");
                if (_target != null)
                {
                    Debug.Log("1");
                    ShootAtTarget(_target);
                }
            }
            */
        }

        private IEnumerator ShootAutomatically()
        {
            while (true) // Бесконечный цикл для автоматической стрельбы
            {
                ShootAtTarget(_target);
                yield return new WaitForSeconds(_fireRate); // Ждём заданный интервал
            }
        }
        
        public GameObject FindTarget()
        {
            // Получаем все коллайдеры в радиусе от позиции персонажа
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _detectionRadius);
        
            foreach (var hitCollider in hitColliders)
            {
                // Проверяем, имеет ли объект тег "Enemy"
                if (hitCollider.CompareTag("Enemy"))
                {
                    return hitCollider.gameObject; // Возвращаем найденный объект
                }
            }

            return null; // Если цель не найдена, возвращаем null
        }
        
        private void OnDrawGizmosSelected()
        {
            // Визуализация радиуса поиска в редакторе
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionRadius);
        }

        // Метод для стрельбы в цель
        private void ShootAtTarget(GameObject target)
        {
            // Создаём пулю и устанавливаем её позицию
            GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);

            Bullet bulletComponent = bullet.GetComponent<Bullet>();

            if (bulletComponent != null)
            {
                bulletComponent.SetDamage(_bulletDamage);

                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

                if (bulletRb != null)
                {
                    // Устанавливаем направление к цели
                    Vector3 direction = (target.transform.position - _shootPoint.position).normalized;
                    bulletRb.velocity = direction * _bulletSpeed;

                    // Уничтожаем пулю через 5 секунд, если она не уничтожена раньше
                    //Destroy(bullet, 5f);
                }
            }
        }
    }
}