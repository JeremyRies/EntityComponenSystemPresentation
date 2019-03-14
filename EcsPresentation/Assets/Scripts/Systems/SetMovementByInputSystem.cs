using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class SetMovementByInputSystem : MonoBehaviour
    {
        private static SetMovementByInputSystem _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }

        private void Update()
        {
            var entities = ComponentHelper.GetMatchingEntities<InputComponent, MovementComponent>();

            ExecuteForAll(entities);
        }

        private void ExecuteForAll(Dictionary<int, Tuple<InputComponent, MovementComponent>> entities)
        {
            foreach (var entity in entities)
            {
                var inputComponent = entity.Value.Item1;
                var movementComponent = entity.Value.Item2;

                ExecuteForOne(inputComponent, movementComponent);
            }
        }

        private void ExecuteForOne(InputComponent inputComponent, MovementComponent movementComponent)
        {
            movementComponent.Direction = new Vector2(inputComponent.XInput, inputComponent.YInput);
        }
    }
}