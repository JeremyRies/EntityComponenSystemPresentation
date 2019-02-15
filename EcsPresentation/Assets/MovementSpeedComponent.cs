using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

public class MovementSpeedComponent : MonoBehaviour
{
    public float Speed;
}

public class PositionComponent : MonoBehaviour
{
    public Vector2 Position;
}

public class MoveSpeedSystem : MonoBehaviour
{
    private static MoveSpeedSystem _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Update()
    {
        MovementSpeedComponent[] entitiesWithMovementSpeedComponents = FindObjectsOfType<MovementSpeedComponent>();
        
    }
}