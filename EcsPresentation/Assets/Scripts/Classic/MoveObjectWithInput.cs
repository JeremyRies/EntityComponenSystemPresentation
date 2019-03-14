using UnityEngine;

namespace Classic
{
    public class MoveObjectWithInput : MonoBehaviour
    {
        public float Speed;
        
        private void Update()
        {
            var xInput = Input.GetAxis("Horizontal");
            var yInput = Input.GetAxis("Vertical");
            
            transform.position += new Vector3(xInput,yInput,0) * Speed;
        }
    }
}