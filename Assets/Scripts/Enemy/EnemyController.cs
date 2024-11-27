using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour, IDamage
    {
        [SerializeField] private int _health = 100;
        
        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}