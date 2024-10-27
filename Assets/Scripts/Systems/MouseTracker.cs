using System;
using UnityEngine;

namespace Sandbox
{
    public class MouseTracker : MonoBehaviour
    {
        private Camera _camera;
        private Vector3 _mousePosition;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            /*
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // вычисляем разницу между текущим положением и положением мыши
            Vector3 difference = _mousePosition - transform.position; 
            difference.Normalize();
            // вычисляемый необходимый угол поворота
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            // Применяем поворот вокруг оси Z
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
            */
            
            
            Vector3 screenMousePosition = Input.mousePosition;
            Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition); 
            
            transform.LookAt(worldMousePosition);
            
        }
    }
}