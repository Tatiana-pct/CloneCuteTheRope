using UnityEngine;

public class Segment : MonoBehaviour
{
    Rigidbody2D _rb;
    HingeJoint2D _joint;
    Collider2D _collider;

    public HingeJoint2D Joint { get => _joint;}
    public Rigidbody2D Rb { get => _rb;}


    // Start is called before the first frame update
    void Awake()
    {
        _joint = GetComponent<HingeJoint2D>();
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
