using System;
using UnityEngine;

namespace Sandbox
{
    public class InputManager : MonoBehaviour
    {
        public event Action<float> OnMoveX;
        public event Action<float> OnMoveZ;
        public event Action OnAttack; 

        public void Update()
        {
            /*
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnAttack();
            }
            */
            
            float directionX = 0;
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                directionX = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                directionX = 1;
            }
            else
            {
                directionX = 0;
            }
            
            float directionZ = 0;
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                directionZ = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                directionZ = -1;
            }
            else
            {
                directionZ = 0;
            }
            
            OnMoveX?.Invoke(directionX);
            OnMoveZ?.Invoke(directionZ);
        }
    }
}