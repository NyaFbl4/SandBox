using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour, IDamage
    {
        [SerializeField] private int _health = 100;
        
        public void TakeDamage(int damage)
        {
            _health -= damage;
            
            Debug.Log(_health);
            
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}