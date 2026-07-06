using System;
using UnityEngine;

public class Terminator : MonoBehaviour
{
    public event Action Died;

    public void Die()
    {
        Died?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            Die();
        }
    }
}