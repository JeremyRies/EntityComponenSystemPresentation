using UnityEngine;

namespace Systems
{
    public class InputSystem : MonoBehaviour
    {
        private static InputSystem _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }

        private void Update()
        {
            var entities = FindObjectsOfType<InputComponent>();

            ExecuteForAll(entities);
        }

        private void ExecuteForAll(InputComponent[] entities)
        {
            foreach (var entity in entities)
            {
                entity.XInput = Input.GetAxis("Horizontal");
                entity.YInput = Input.GetAxis("Vertical");
            }
        }
    }
}