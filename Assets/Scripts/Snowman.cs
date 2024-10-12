using UnityEngine;

public class Snowman : MonoBehaviour
{
    [SerializeField] private float slideForce;
    [SerializeField] private OtherObjectManager _otherObjectManager;
    private Camera _mainCamera;
    private Rigidbody _rigidbody;
    public bool _collisionEnterOnPresent;

    private void Start()
    {
        _mainCamera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                var slideDirection = hit.point - transform.position;
                slideDirection.Normalize();
                _rigidbody.AddForce(slideDirection * slideForce, ForceMode.VelocityChange);
            }
        }

        _otherObjectManager.LockPositionWithinGameBoard(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Present") && GetComponent<Renderer>().materials[0].color ==
            other.gameObject.transform.GetChild(0).GetComponent<Renderer>().materials[1].color)
        {
            Destroy(other.gameObject);
            _collisionEnterOnPresent = true;
        }
    }
}