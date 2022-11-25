using UnityEngine;

public class SegmentBehaviour : MonoBehaviour
{
    Transform _transform;
    Rigidbody2D _rigidbody;
    HingeJoint2D _joint;
    SpriteRenderer _spriteRenderer;

    Ropegenerator _rope;
    bool _isDestructible;

    public Transform Transform { get => _transform; }
    public Rigidbody2D Rigidbody { get => _rigidbody; }
    public HingeJoint2D Joint { get => _joint; }

    private void Awake()
    {
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _joint = GetComponent<HingeJoint2D>();
    }

    private void Start()
    {
        _spriteRenderer.enabled = false;
    }

    public void SetRope(Ropegenerator rope)
    {
        _rope = rope;
    }

    public void SetUndestructible()
    {
        _isDestructible = false;
    }

    public void Destroy()
    {
        if (_isDestructible)
        {
            _rope.Cut(this);
            Destroy(gameObject);
        }
    }
}
