
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField] private AudioSource _teleportSound;
    [SerializeField] private Image _teleportIcon;
    [SerializeField]private Transform controlPoint;
    [SerializeField]private int segments = 10;
    [SerializeField]private int curvature = -6;
    [SerializeField] private float teleportTimer = 5;
    private float _teleportCoolDonw;
    private bool _canTeleport = true;
    private LineRenderer _lineRenderer;
    private Vector3 worldPos;
    private Camera _camera;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _camera = Camera.main;
        _lineRenderer.positionCount = segments + 1;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _lineRenderer.enabled = true;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -_camera.transform.position.z;
            worldPos = _camera.ScreenToWorldPoint(mousePosition);
            var position = transform.position;
            controlPoint.position = worldPos - new Vector3(3,curvature);
            Vector3[] points = CalculateBezierCurve(position, controlPoint.position, worldPos, segments);
            
            for (int i = 0; i <= segments; i++)
            {
                _lineRenderer.SetPosition(i, points[i]);
            }
           

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _lineRenderer.enabled = false;
            if (_canTeleport)
            {
                var teleportIconColor = _teleportIcon.color; 
                teleportIconColor.a = 0f; 
                _teleportIcon.color = teleportIconColor;
                _teleportCoolDonw = teleportTimer;
                _canTeleport = false;
                _teleportSound.Play();
                worldPos.z = 0;
                transform.position = worldPos;
            }
        }
        CalculateCoolDonw();
       
    }

    private Vector3[] CalculateBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, int numberSegments)
    {
        Vector3[] points = new Vector3[numberSegments + 1];

        for (int i = 0; i <= numberSegments; i++)
        {
            float t = i / (float)numberSegments;
            points[i] = CalculateBezierPoint(t, p0, p1, p2);
        }

        return points;
    }

    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0 + 3 * uu * t * p1 + 3 * u * tt * p2 + ttt * worldPos;

        return p;
    }

    private void CalculateCoolDonw()
    {
        if (_teleportCoolDonw >0)
        {
            _teleportCoolDonw -= Time.deltaTime;
            var fillingImage = Mathf.Clamp01(1-(_teleportCoolDonw / teleportTimer));
            var teleportIconColor = _teleportIcon.color; 
            teleportIconColor.a = fillingImage; 
            _teleportIcon.color = teleportIconColor;
            if (_teleportCoolDonw <= 0)
            {
                _canTeleport = true;
            }
        }
    }
}
