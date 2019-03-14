using UnityEngine;

namespace Classic
{
    public class MovingObject : MonoBehaviour
    {
        public float Speed;
        public Vector2 Direction;
        public Vector2 StartPoint;
        private void Update()
        {
            transform.position = StartPoint + Direction * Speed * Time.time;
        }
    }
}