using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

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
            entities.Add(i, new Tuple<T, T1>(movement, position));
        }

        return entities;
    }
}