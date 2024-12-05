using UnityEngine;

namespace Components
{
    public class CharacterHealthController : MonoBehaviour, IDamage
    {
        [SerializeField] private int _health;

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}