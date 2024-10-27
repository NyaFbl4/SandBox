using System;
using Sandbox;
using UnityEngine;

namespace Components
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;

        private float _dirX = 0;
        private float _dirZ = 0;

        private void OnEnable()
        {
            _inputManager.OnMoveX += OnMoveX;
            _inputManager.OnMoveZ += OnMoveZ;
        }

        private void OnDestroy()
        {
            _inputManager.OnMoveX -= OnMoveX;
            _inputManager.OnMoveZ += OnMoveZ;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector3(_dirX, 0, _dirZ) * _speed;

            /*
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(_dirX, 0, 0);
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(_dirX, 0, 0);
            }
            
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, _dirZ);
            }
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, _dirZ);
            }
            */
        }

        private void OnMoveX(float directionX)
        {
            _dirX = directionX;
            //Debug.Log(_dirX);
        }
        
        private void OnMoveZ(float directionZ)
        {
            _dirZ = directionZ;
            //Debug.Log(_dirZ);
        }
    }
}