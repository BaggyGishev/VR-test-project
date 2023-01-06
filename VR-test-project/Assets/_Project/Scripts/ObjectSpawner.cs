using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;

    public void Spawn()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}