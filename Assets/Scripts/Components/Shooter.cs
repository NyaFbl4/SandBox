using UnityEngine;

namespace Components
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _bulletSpeed = 20f;
        
        [SerializeField] private float _detectionRadius = 10f;
        [SerializeField] private GameObject _target;
        

        private void Update()
        {
            _target = FindTarget();
            
            if (Input.GetKeyDown(KeyCode.Space)) // Проверяем нажатие пробела для стрельбы
            {
                if (_target != null)
                {
                    ShootAtTarget(_target);
                }
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
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            if (bulletRb != null)
            {
                // Устанавливаем направление к цели
                Vector3 direction = (target.transform.position - transform.position).normalized;
                bulletRb.velocity = direction * _bulletSpeed;

                // Уничтожаем пулю через 5 секунд, если она не уничтожена раньше
                Destroy(bullet, 5f);
            }
        }
    }
}