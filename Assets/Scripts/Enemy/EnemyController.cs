using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour, IDamage
    {
        [SerializeField] private GameObject _expiriencePrefab;
        [SerializeField] private int _expirience;
        
        [SerializeField] private int _health = 100;
        [SerializeField] private int _damage;
        
        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Destroy(gameObject);

                GameObject expiriencePrefab = Instantiate(_expiriencePrefab, transform.position , Quaternion.identity);

                if (expiriencePrefab != null)
                {
                    ExperiencePickup experiencecomponent = expiriencePrefab.GetComponent<ExperiencePickup>();
                    experiencecomponent.SetExperience(_expirience);
                }
            }
        }

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