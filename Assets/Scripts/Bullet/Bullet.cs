using System;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Collider _bulletCollider;
        
        private int _damage;

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        /*
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log("!!!!");
            }
        }
        */
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Collision detected with: " + other.gameObject.name);
            
            if (other.CompareTag("Enemy"))
            {
                IDamage damageComponent = other.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                    Debug.Log("Damage dealt to enemy.");
                }

                //Destroy(gameObject); // Уничтожаем пулю
            }
            else
            {
                // Если это не враг, ничего не делаем
                Debug.Log("Ignoring collision with: " + other.gameObject.name);
            }
        }

        /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            IDamage damageComponent = other.GetComponent<IDamage>();
            if (damageComponent != null)
            {
                damageComponent.TakeDamage(_damage);
                Debug.Log("Damage dealt to enemy.");
            }

            Destroy(gameObject); // Уничтожаем пулю
        }
        // Игнорируем все другие столкновения
    }
    */
    }
}