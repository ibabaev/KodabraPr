using UnityEngine;

public class Platform : MonoBehaviour
{
    public float PlatformSpeed = 1f;

    public Vector3 Direction = Vector3.up;

    private bool _forward;
    private bool _lock;

    private void OnTriggerEnter(Collider other)
    {
        if (!_lock && (other.name == "Detector1" || other.name == "Detector2"))
        {
            _lock = true;

            if (_forward == true)
            {
                _forward = false;
            }
            else
            {
                _forward = true;
            }
            //or _forward = !_forward;)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_lock && (other.name == "Detector1" || other.name == "Detector2"))
        {
            _lock = false;
        }
    }
    private void Update()
    {
        if (_forward)
        {
            MoveForward();
        }
        else
        {
            MoveBackward();
        }
    }

    private void MoveForward()
    {
        transform.position += Direction * PlatformSpeed * Time.deltaTime;
    }

    private void MoveBackward()
    {
        transform.position -= Direction * PlatformSpeed * Time.deltaTime;
    }
}