using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("The speed of the player's left and right movement.")]
    [SerializeField] private float _Speed = 5f;
    [Tooltip("The value at which the player cannot move past horizontally")]
    [SerializeField] private float _XMin = 0.0f, _XMax = 0.0f;

    /// The player's direction with speed.
    private Vector3 _Velocity = Vector3.zero;
    /// Reference to the player's Rigibody component.
    private Rigidbody2D _Rigidbody2D = null;
    /// Reference to the player's Transform component.
    private Transform _Transform = null;

    private void Awake ()
    {
        AssignReferences ();
    }

    private void AssignReferences ()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D> ();
        _Transform = GetComponent<Transform> ();
        GetComponent<Collider2D> ().isTrigger = false;
    }

    private void Start ()
    {
        SetDefaults ();
    }

    private void SetDefaults ()
    {
        _Rigidbody2D.gravityScale = 0.0f;
        _Rigidbody2D.isKinematic = false;
    }

    private void Update ()
    {
        GetInput ();
    }

    private void GetInput ()
    {
        var dir = new Vector3 (
            Input.GetAxis ("Horizontal"), 
            0.0f, 
            0.0f
        );

        _Velocity = dir * _Speed;
    }

    private void FixedUpdate ()
    {
        Move ();
    }

    private void Move ()
    {
        _Rigidbody2D.velocity = _Velocity * Time.fixedDeltaTime;

        _Rigidbody2D.position = new Vector3 (
            Mathf.Clamp (_Rigidbody2D.position.x, _XMin, _XMax),
            0.0f,
            0.0f
        );
    }

    private void Die ()
    {
        Destroy (this.gameObject);
    }
}
