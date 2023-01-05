using UnityEngine;

public interface IProjectile
{
    GameObject gameObject { get; }
    Transform transform { get; }
}