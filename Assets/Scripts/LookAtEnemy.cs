using UnityEngine;

namespace Assets.Scripts
{
    public class LookAtEnemy : MonoBehaviour
    {
        public Transform enemy; // ссылка на объект врага

        void Update()
        {
            if (enemy != null)
            {
                // Получаем направление от персонажа к врагу
                Vector3 direction = enemy.position - transform.position;

                // Вычисляем угол вращения
                Quaternion rotation = Quaternion.LookRotation(direction);

                // Поворачиваем персонажа к врагу
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
            }
        }
    }
}