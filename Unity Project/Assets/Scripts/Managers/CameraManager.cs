using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    [SerializeField] private Transform _target;
    [SerializeField] private bool isTracking = true;
    [SerializeField] private float _cameraLerpSpeed = 4.0f;
    
    private Vector3 _currentTarget;

    private void Start()
    {
        
    }

    private void Update()
    {
        HandleCamera(_camera);
        HandleTarget();
    }

    private void HandleCamera(Camera camera)
    {
        Vector3 dest;

        dest = _currentTarget;
        dest.z = camera.transform.position.z;
        camera.transform.position = Vector3.Lerp(camera.transform.position, dest, _cameraLerpSpeed * Time.deltaTime);
    }

    private void HandleTarget()
    {
        _currentTarget = _target.position;
    }
}
