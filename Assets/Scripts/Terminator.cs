using UnityEngine;
using UnityEngine.SceneManagement;

public class Terminator : MonoBehaviour
{
    public void Die()
    {
        Debug.Log("Терминатор погиб!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            Die();
        }
    }
}