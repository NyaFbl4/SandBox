using System;
using Components;
using UnityEngine;

namespace Assets.Scripts
{
    public class ExperiencePickup : MonoBehaviour
    {
        [SerializeField] private int _experience;

        public void SetExperience(int exp)
        {
            _experience += exp;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Character")) // Проверяем, что это враг
            {
                Debug.Log(other.gameObject.name);
                LvlComponent lvlComponent = other.GetComponent<LvlComponent>();
                
                if (lvlComponent != null)
                {
                    lvlComponent.UpdateExperience(_experience);
                }
                
                Destroy(gameObject); // Уничтожаем пулю
            }
        }
    }
}