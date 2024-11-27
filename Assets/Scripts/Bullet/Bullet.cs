using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;
        
        private void OnCollisionEnter(Collision collision)
        {
            IDamage damage = collision.gameObject.GetComponent<IDamage>();

            if (damage != null)
            {
                damage.TakeDamage(_damage);
            }
            
            Destroy(gameObject);
        }
    }
}