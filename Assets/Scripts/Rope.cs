using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [Tooltip("reference au crochet")]
    [SerializeField] Segment _linkPrefab;
    //[SerializeField] Transform _segmentContainer;
    private Transform _transform;


    [Tooltip("reference aux liens")]
    [SerializeField] int _links = 5;
    private HingeJoint2D _joint;

    List<Segment> _cutedsSegments = new List<Segment>();
    List<Segment> _segments = new List<Segment>();

    private LineRenderer _lineRenderer;
    [SerializeField] private LineRenderer _cutedLineRenderer;

    [Tooltip("reference aux Candy")]
    [SerializeField] Rigidbody2D _CandyRb;
    private Rigidbody2D _candy;

    bool _iscut;


    // Start is called before the first frame update
    void Awake()
    {
        _joint = GetComponent<HingeJoint2D>();

        _lineRenderer = GetComponent<LineRenderer>();
        _candy = GameObject.FindGameObjectWithTag("Candy").GetComponent<Rigidbody2D>();
        _transform = transform;

        GenerateRope();

    }

    // Update is called once per frame
    void Update()
    {

        _lineRenderer.SetPosition(0, transform.position);

        for (int i = 0; i < _segments.Count; i++)
        {
            _lineRenderer.SetPosition(i + 1, _segments[i].transform.position);
        }


        if (_iscut)
        {
            for (int i = 0; i < _cutedsSegments.Count; i++)
            {
                _cutedLineRenderer.SetPosition(i, _cutedsSegments[i].transform.position);
            }
        }
    }

    #region GenerateRope
    void GenerateRope()
    {

        for (int i = 0; i < _links; i++)
        {
            _segments.Add(Instantiate(_linkPrefab, transform));
            if (i == 0)
            {
                _joint.connectedBody = _segments[i].Rb;

            }
            else
            {
                _segments[i - 1].Joint.connectedBody = _segments[i].Rb;

            }
        }

        _segments[_segments.Count - 1].Joint.connectedBody = _candy;

        _lineRenderer.positionCount = _segments.Count + 1;
        
    }
    #endregion


    public void Cut(Segment segment)
    {
        if (!_iscut)
        {
            _iscut = true;
            int cutIndex = _segments.IndexOf(segment);
            _segments.RemoveAt(cutIndex);
            Destroy(segment.gameObject);

            _cutedsSegments = _segments.GetRange(cutIndex, _segments.Count - cutIndex);
            _segments = _segments.GetRange(0, cutIndex);

            _lineRenderer.positionCount = _segments.Count + 1;
            _cutedLineRenderer.positionCount = _cutedsSegments.Count;
        }
    }
}
