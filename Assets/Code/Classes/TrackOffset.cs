using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class TrackOffset : MonoBehaviour
{
    [Tooltip("The speed for the track to move at, giving the appearance of motion.")]
    private float _Speed = 0.0f;

    /// The offset of the current texture on the object.
    private Vector2 _Offset = Vector2.zero;
    /// Reference to the object's renderer component.
    private Renderer _Renderer = null;

    private void Awake ()
    {
        AssignReferences ();
    }

    private void AssignReferences ()
    {
        _Renderer = GetComponent<Renderer> ();
    }

    private void Update ()
    {
        MoveTrack ();
    }

    private void MoveTrack ()
    {
        _Offset = new Vector2 (0.0f, Time.time * _Speed);
        _Renderer.material.mainTextureOffset = _Offset;
    }
}
