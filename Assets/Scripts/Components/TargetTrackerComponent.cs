using System;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class TargetTrackerComponent : MonoBehaviour
    {
        [SerializeField] private float _detectionRadius = 10f;
        
        [SerializeField] private GameObject _target;
        [SerializeField] private List<GameObject> _targets;

        public List<GameObject> GetCurrentTargets()
        {
            return _targets;
        }
        
        private void Update()
        {
            FindTarget();
        }
        
        public void  FindTarget()
        {
            _targets.Clear();
            // Получаем все коллайдеры в радиусе от позиции персонажа
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _detectionRadius);
        
            foreach (var hitCollider in hitColliders)
            {
                // Проверяем, имеет ли объект тег "Enemy"
                if (hitCollider.CompareTag("Enemy"))
                {
                    _targets.Add(hitCollider.gameObject);
                    
                    //return hitCollider.gameObject; // Возвращаем найденный объект
                }
            }
        }
        
        private void OnDrawGizmosSelected()
        {
            // Визуализация радиуса поиска в редакторе
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionRadius);
        }
    }
}