using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Rotation")] [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform turretTransform;
    [Header("Shooting")] [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 55f;
    [SerializeField] private float shootDelay = 1.5f;
    [SerializeField] private ParticleSystem shootVFX;


    private bool _isReloaded = true;
    private int _yDir;

    public void OnRotateLeft()
    {
        StopAllCoroutines();
        if (_yDir == -1)
        {
            _yDir = 0;
            return;
        }

        _yDir = -1;
        StartCoroutine(RotationRoutine(_yDir));
    }

    public void OnRotateRight()
    {
        StopAllCoroutines();
        if (_yDir == 1)
        {
            _yDir = 0;
            return;
        }

        _yDir = 1;
        StartCoroutine(RotationRoutine(_yDir));
    }

    public void Shoot()
    {
        if (!_isReloaded)
            return;

        var projRb = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>();
        projRb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        _isReloaded = false;
        shootVFX.Play();

        StartCoroutine(ReloadingRoutine());
    }

    private IEnumerator RotationRoutine(float yDir)
    {
        while (true)
        {
            turretTransform.Rotate(Vector3.up * (yDir * rotationSpeed * Time.deltaTime), Space.Self);
            yield return null;
        }
    }

    private IEnumerator ReloadingRoutine()
    {
        yield return new WaitForSeconds(shootDelay);
        _isReloaded = true;
    }
}