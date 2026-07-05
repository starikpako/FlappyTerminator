using UnityEngine;
using UnityEngine.InputSystem;

public class TerminatorShooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_bulletPrefab != null && _shootPoint != null)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
            if (bullet.TryGetComponent(out Bullet bulletScript))
            {
                bulletScript.Initialize(transform.right, true);
            }
        }
    }
}