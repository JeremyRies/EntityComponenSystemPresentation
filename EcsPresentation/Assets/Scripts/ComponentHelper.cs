using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public static class ComponentHelper
{
    public static Dictionary<int, Tuple<T,T1>> FindObjectsWithComponents<T,T1>() where T : Component where T1 : Component
    { 
        var entities = new Dictionary<int, Tuple<T, T1>>();
        T[] entitiesWithTComponent = Object.FindObjectsOfType<T>();
        T1[] entitiesWithT1Component = Object.FindObjectsOfType<T1>();

        var entitiesWithBothComponents = entitiesWithTComponent.Select(ent => ent.gameObject)
            .Intersect(entitiesWithT1Component.Select(ent => ent.gameObject)).ToList();

        for (var index = 0; index < entitiesWithBothComponents.Count; index++)
        {
            var entry = entitiesWithBothComponents[index];
            var t = entry.GetComponent<T>();
            var t1 = entry.GetComponent<T1>();
            entities.Add(index, new Tuple<T, T1>(t, t1));
        }

        return entities;
    }

    public static List<GameObject> FindObjectsWithComponents(List<Component> filter)
    {
        var entities = new Dictionary<int, List<Component>>();

        var candidates = filter.Select(comp => Object.FindObjectsOfType(comp.GetType())).Select(o => o.Cast<Component>());
        var objectsThatMatchFilter = candidates.Select(cand => cand.Select(comp => comp.gameObject)).IntersectAll();
        
        return objectsThatMatchFilter;
    }
    public static List<T> IntersectAll<T>(this IEnumerable<IEnumerable<T>> lists)
    {
        HashSet<T> hashSet = null;
        foreach (var list in lists)
        {
            if (hashSet == null)
            {
                hashSet = new HashSet<T>(list);
            }
            else
            {
                hashSet.IntersectWith(list);
            }
        }
        return hashSet == null ? new List<T>() : hashSet.ToList();
    }
}