using UnityEngine;

namespace Systems
{
    public class SetPositionSystem : MonoBehaviour
    {
        private static SetPositionSystem _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }

        private void Update()
        {
            var entities = FindObjectsOfType<PositionComponent>();

            ExecuteForAll(entities);
        }

        private void ExecuteForAll(PositionComponent[] entities)
        {
            foreach (var entity in entities)
            {
                entity.gameObject.transform.position = entity.Position;
            }
        }
    }
}