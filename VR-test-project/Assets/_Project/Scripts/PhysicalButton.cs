using UnityEngine;
using UnityEngine.Events;

public class PhysicalButton : MonoBehaviour
{
    [SerializeField] private float deadZone = 0.025f;
    [SerializeField] private float threshold = .1f;
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private UnityEvent onReleased;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    private void Awake()
    {
        _joint = GetComponentInChildren<ConfigurableJoint>();
        _startPos = _joint.transform.localPosition;
    }

    private void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1f)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0f)
            Released();
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed?.Invoke();
        Debug.Log("Pressed");
    }

    private void Released()
    {
        _isPressed = false;
        onReleased?.Invoke();
        Debug.Log("Released");
    }

    private float GetValue()
    {
        var val = Vector3.Distance(_startPos, _joint.transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(val) < deadZone)
            val = 0f;

        return Mathf.Clamp(val, -1f, 1f);
    }
}