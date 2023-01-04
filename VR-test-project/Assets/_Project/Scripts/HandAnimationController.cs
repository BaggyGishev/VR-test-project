using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimationController : MonoBehaviour
{
    [SerializeField] private ActionBasedController controller;
    [SerializeField] private float animationSpeed = 0.5f;

    private const string GRIP_PARAM = "Grip";
    private const string TRIGGER_PARAM = "Trigger";

    private float _gripTarget, _triggerTarget;
    private float _gripCurrent, _triggerCurrent;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetInputs();
        AnimateHand();
    }

    private void GetInputs()
    {
        _gripTarget = controller.selectAction.action.ReadValue<float>();
        _triggerTarget = controller.activateAction.action.ReadValue<float>();
    }
    
    private void AnimateHand()
    {
        if (Math.Abs(_gripCurrent - _gripTarget) > 0.01f)
        {
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * animationSpeed);
            _animator.SetFloat(GRIP_PARAM, _gripCurrent);
        }

        if (Math.Abs(_triggerCurrent - _triggerTarget) > 0.01f)
        {
            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * animationSpeed);
            _animator.SetFloat(TRIGGER_PARAM, _triggerCurrent);
        }
    }
}