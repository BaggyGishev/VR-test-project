using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRDirectInteractor))]
public class InteractedObjectParenter : MonoBehaviour
{
    private XRDirectInteractor _directInteractor;

    private void Awake()
    {
        _directInteractor = GetComponent<XRDirectInteractor>();

        _directInteractor.selectEntered.AddListener(OnSelectEntered);
        _directInteractor.selectExited.AddListener(OnSelectExit);
    }

    private void OnDestroy()
    {
        _directInteractor.selectEntered.RemoveAllListeners();
        _directInteractor.selectExited.RemoveAllListeners();
    }

    private void OnSelectEntered(SelectEnterEventArgs enterEventArgs)
    {
        var interactableTrans = enterEventArgs.interactableObject.transform;
        interactableTrans.SetParent(transform);
    }

    private void OnSelectExit(SelectExitEventArgs exitEventArgs)
    {
        var interactableTrans = exitEventArgs.interactableObject.transform;
        interactableTrans.SetParent(null);
    }
}