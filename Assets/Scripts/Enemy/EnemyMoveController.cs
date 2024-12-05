using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyMoveController : MonoBehaviour
    {
        [SerializeField] private Transform _character;
        [SerializeField] private float _moveSpeed;

        private void OnEnable()
        {
            GameObject character = GameObject.FindGameObjectWithTag("Character");

            if (character != null)
            {
                _character = character.transform;
            }
        }

        private void Update()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            if (_character != null)
            {
                float distance = Vector3.Distance(transform.position, _character.position);
                
                // Рассчитываем направление к цели
                Vector3 direction = (_character.position - transform.position).normalized;
                
                // Обновляем позицию врага
                transform.position += direction * _moveSpeed * Time.deltaTime;
            }
        }
    }
}