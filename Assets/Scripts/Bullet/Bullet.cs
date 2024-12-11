using System;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class Bullet : MonoBehaviour
    {
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
        */

    
        //private void OnCollisionEnter(Collision other)
        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log(other.gameObject.name);
            
            if (other.gameObject.CompareTag("Enemy")) // Проверяем, что это враг
            {
                Debug.Log(other.gameObject.name);
                // Обработка урона врагу
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }

                Destroy(gameObject); // Уничтожаем пулю
            }
        }
    }
}