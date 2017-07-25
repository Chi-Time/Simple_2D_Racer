using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D))]
public class Obstacle : MonoBehaviour
{
    [Tooltip("The speed at which the obstacle moves down the screen.")]
    [SerializeField] private float _Speed = 0.0f;
    [Tooltip("The distance before the object is culled from play.")]
    [Range(-5.0f, -25.0f)]
    [SerializeField] private float _CullingRange = 0.0f;

    /// Reference to the object's rigidbody component.
    private Rigidbody2D _Rigidbody2D = null;
    /// Reference to the objects transform component.
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
        CheckPosition ();
    }

    private void CheckPosition ()
    {
        if (_Transform.position <= _CullingRange)
            Cull ();
    }

    private void FixedUpdate ()
    {
        Move ();
    }

    private void Move ()
    {
        _Rigidbody2D.velocity = Vector2.down * _Speed * Time.fixedDeltaTime;
    }

    private void Cull ()
    {
        Destroy (this.gameObject);
    }
}
