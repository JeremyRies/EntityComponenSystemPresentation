using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class AdvancedInputSystem : MonoBehaviour
    {
        private static AdvancedInputSystem _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }

        private void Update()
        {
            var entities = ComponentHelper.FindObjectsWithComponents<InputComponent,IdComponent>();

            ExecuteForAll(entities);
        }

        private void ExecuteForAll(Dictionary<int, Tuple<InputComponent, IdComponent>> entities)
        {
            foreach (var entity in entities)
            {
                var idComponent = entity.Value.Item2;
                var inputComponent = entity.Value.Item1;

                if (idComponent.ID == 1)
                {
                    inputComponent.XInput = Input.GetAxis("Horizontal");
                    inputComponent.YInput = Input.GetAxis("Vertical");
                }
                else if(idComponent.ID == 2)
                {
                    inputComponent.XInput = Input.GetAxis("Vertical");
                    inputComponent.YInput = Input.GetAxis("Horizontal");
                }
                else if (idComponent.ID == 3)
                {
                    inputComponent.XInput = - Input.GetAxis("Horizontal");
                    inputComponent.YInput = - Input.GetAxis("Vertical");
                }
            }
        }
    }
}