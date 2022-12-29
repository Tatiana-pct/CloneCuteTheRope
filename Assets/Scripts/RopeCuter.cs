using UnityEngine;

public class RopeCuter : MonoBehaviour
{

    Transform _transform;
    TrailRenderer _trailRenderer;

    // Start is called before the first frame update
    void Awake()
    {

        _transform = transform;
        _trailRenderer = GetComponent<TrailRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (Input.touchCount > 0 && touch.phase == TouchPhase.Began)
            {
               
                StartSwipe(touch);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                
                OnSwipe(touch);

            }
        }

    }

    private void StartSwipe(Touch touch)
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        _transform.position = touchPos;
        _trailRenderer.Clear();
    }

    private void OnSwipe(Touch touch)
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        _transform.position = touchPos;
        Vector2 OldPos = Camera.main.ScreenToWorldPoint(touch.position - touch.deltaPosition);

        RaycastHit2D hit = Physics2D.Raycast(touchPos, OldPos - touchPos, Vector3.Distance(touchPos, OldPos));
        if(hit && hit.collider.CompareTag("Segment"))
        {
           
            Segment segment = hit.collider.GetComponent<Segment>();
            Rope rope = segment.transform.parent.GetComponent<Rope>();
            rope.Cut(segment);

        }

    }
}

