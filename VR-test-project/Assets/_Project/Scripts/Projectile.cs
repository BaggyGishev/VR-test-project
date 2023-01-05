using UnityEngine;


public class Projectile : MonoBehaviour, IProjectile
{
    [SerializeField] private float lifeTime = 10f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}