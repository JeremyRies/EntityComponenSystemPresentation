using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class MoveSystem : MonoBehaviour
    {
        private static MoveSystem _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }

        private void Update()
        {
            var entities = ComponentHelper.GetMatchingEntities<MovementComponent,PositionComponent>();

            ExecuteForAll(entities);
        }

        private void ExecuteForAll(Dictionary<int, Tuple<MovementComponent, PositionComponent>> entities)
        {
            foreach (var entity in entities)
            {
                var movementSpeedComponent = entity.Value.Item1;
                var positionComponent = entity.Value.Item2;

                ExecuteForOne(movementSpeedComponent, positionComponent);
            }
        }

        private void ExecuteForOne(MovementComponent movementComponent, PositionComponent positionComponent)
        {
            positionComponent.Position += movementComponent.Direction * movementComponent.Speed * Time.deltaTime;
        }
    }
}