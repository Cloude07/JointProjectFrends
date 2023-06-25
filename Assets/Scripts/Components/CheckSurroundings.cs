using System;
using UnityEngine;

namespace CloudeDev.Components
{
    [Serializable]
    public class CheckSurroundings
    {
        [Header("IsGrounded_Check")]
        [SerializeField] private float _groundedCheckRadius = 0.5f;
        [SerializeField] private LayerMask _groundedAndLayerLayer;
        [SerializeField] private Transform _groundCheckPosition;

        public bool IsGrounded()
        {
            return Physics.CheckSphere(_groundCheckPosition.position, _groundedCheckRadius, _groundedAndLayerLayer);
        }
    }
}