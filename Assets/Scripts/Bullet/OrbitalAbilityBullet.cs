using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class OrbitalAbilityBullet : MonoBehaviour
    {
        private int _damage;
        
        public void SetDamage(int damage)
        {
            _damage = damage;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            
            if (other.CompareTag("Enemy"))
            {
                IDamage damageComponent = other.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }
            }
        }
    }
}