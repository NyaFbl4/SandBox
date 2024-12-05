using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour, IDamage
    {
        [SerializeField] private int _health = 100;
        [SerializeField] private int _damage;
        
        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        /*
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Character"))
            {
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();

                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }
                
                Debug.Log("damage");
            }
        }
        */
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Character")
            {
                IDamage damageComponent = other.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }
                
                Debug.Log("damage");
            }
        }
        
    }
}