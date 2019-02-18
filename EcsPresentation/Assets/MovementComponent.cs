using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using Object = UnityEngine.Object;

public class MovementComponent : MonoBehaviour, IMyComponent
{
    public float Speed;
    public Vector2 Direction;
}

public class PositionComponent : MonoBehaviour , IMyComponent
{
    public Vector2 Position;
}

public class MovePlayerSystem : MonoBehaviour
{
    private static MovePlayerSystem _instance;

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

public static class ComponentHelper
{
    public static Dictionary<int, Tuple<T,T1>> GetMatchingEntities<T,T1>() where T : Component where T1 : Component
    { 
        var entities = new Dictionary<int, Tuple<T, T1>>();
        T[] entitiesWithAMovementSpeedComponent = Object.FindObjectsOfType<T>();
        T1[] entitiesWithAPositionComponent = Object.FindObjectsOfType<T1>();

        var entitiesWithBothComponents = entitiesWithAMovementSpeedComponent.Select(ent => ent.gameObject)
            .Intersect(entitiesWithAPositionComponent.Select(ent => ent.gameObject)).ToList();


        for (int i = 0; i < entitiesWithBothComponents.Count; i++)
        {
            var entry = entitiesWithAPositionComponent[i];
            var movement = entry.GetComponent<T>();
            var position = entry.GetComponent<T1>();
            entities.Add(1, new Tuple<T, T1>(movement, position));
        }

        return entities;
    }
}

public interface IMyComponent
{
}