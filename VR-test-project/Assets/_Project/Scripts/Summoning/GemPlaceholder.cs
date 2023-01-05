using System;
using UnityEngine;

public class GemPlaceholder : MonoBehaviour
{
    public event Action<bool> StatusChanged;
    public bool IsGemPlaced { get; private set; }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Gem gem))
            return;

        IsGemPlaced = true;
        StatusChanged?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out Gem gem))
            return;

        IsGemPlaced = false;
        StatusChanged?.Invoke(false);
    }
}