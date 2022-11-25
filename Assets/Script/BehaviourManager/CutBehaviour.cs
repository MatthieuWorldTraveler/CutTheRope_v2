using UnityEngine;

public class CutBehaviour : MonoBehaviour
{
    Transform _transform;
    TrailRenderer _trailRenderer;
    [SerializeField] LayerMask _whatIsBubble;

    private void Awake()
    {
        _transform = transform;
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartSwipe(touch);
            }
            else if (touch.phase == TouchPhase.Moved)
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

        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 20f, _whatIsBubble);

        if (hit)
            Destroy(hit.collider.gameObject);

    }

    private void OnSwipe(Touch touch)
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        _transform.position = touchPos;
        Vector2 previousPos = Camera.main.ScreenToWorldPoint(touch.position - touch.deltaPosition);

        RaycastHit2D hit = Physics2D.Raycast(touchPos, previousPos - touchPos, Vector3.Distance(touchPos, previousPos));

        if (hit && hit.collider.CompareTag("Segment"))
        {
            SegmentBehaviour segment = hit.collider.GetComponent<SegmentBehaviour>();
            Ropegenerator rope = segment.transform.parent.parent.GetComponent<Ropegenerator>();
            rope.Cut(segment);
        }
    }
}
