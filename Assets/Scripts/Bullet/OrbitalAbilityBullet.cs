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
        
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.name);
            
            if (other.gameObject.CompareTag("Enemy"))
            {
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }
            }
        }
    }
}