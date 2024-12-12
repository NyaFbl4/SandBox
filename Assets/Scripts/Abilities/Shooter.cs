using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Bullet;
using UnityEngine;

namespace Components
{
    public class Shooter : MonoBehaviour, ILvlUp
    {
        [SerializeField] private TargetTrackerComponent _targetTracker;
        
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _bulletSpeed = 20f;
        [SerializeField] private int _bulletDamage = 5;
        
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _fireRate; // Интервал между выстрелами

        [SerializeField] private int _maxCurrentShots;

        private Coroutine _shootingCoroutine;

        private void Update()
        {
            List<GameObject> targets = _targetTracker.GetCurrentTargets();

            // Запускаем или останавливаем корутину в зависимости от наличия целей
            if (targets.Count > 0 && _shootingCoroutine == null)
            {
                _shootingCoroutine = StartCoroutine(ShootAutomatically(targets));
            }
            else if (targets.Count == 0 && _shootingCoroutine != null)
            {
                StopCoroutine(_shootingCoroutine);
                _shootingCoroutine = null;
            }
            /*
            GameObject target = _targetTracker.GetCurrentTargets();

            // Запускаем или останавливаем корутину в зависимости от наличия цели
            if (target != null && _shootingCoroutine == null)
            {
                _shootingCoroutine = StartCoroutine(ShootAutomatically(target));
            }
            else if (target == null && _shootingCoroutine != null)
            {
                StopCoroutine(_shootingCoroutine);
                _shootingCoroutine = null;
            }
            */
        }

        public void LvlUp()
        {
            
        }

        private IEnumerator ShootAutomatically(List<GameObject> targets)
        {
            while (true) // Бесконечный цикл для автоматической стрельбы
            {
                ShootAtTargets(targets);
                yield return new WaitForSeconds(_fireRate); // Ждём заданный интервал
            }
        }

        private void ShootAtTargets(List<GameObject> targets)
        {
            int shotsFired = 0;
            
            // Проходим по всем целям и стреляем в каждую, пока не достигнем максимального количества выстрелов
            foreach (GameObject target in targets)
            {
                if (shotsFired >= _maxCurrentShots)
                    break; // Останавливаем стрельбу, если достигли лимита

                ShootAtTarget(target);
                shotsFired++;
            }
        }
        
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
                }

                /*
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
                    }
                }
                */
            }
        }
    }
}