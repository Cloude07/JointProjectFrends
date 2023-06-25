using System;
using UnityEngine;

namespace CloudeDev.Components
{
    public class LivesPoints : MonoBehaviour
    {
        [SerializeField] private int lives;
        public event Action isDead;

        public void TakeDamage(int damage)
        {
            lives -= damage;
            if (lives <= 0)
            {
                isDead?.Invoke();
            }
        }
    }
}