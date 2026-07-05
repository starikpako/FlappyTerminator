using UnityEngine;
using UnityEngine.InputSystem; 

[RequireComponent(typeof(Rigidbody2D))]
public class TerminatorMover : MonoBehaviour
{
    [SerializeField] private float _tapForce = 5f;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame) ||
            (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame))
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, _tapForce);
        }
    }
}