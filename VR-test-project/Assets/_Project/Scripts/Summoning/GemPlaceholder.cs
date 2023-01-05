using System;
using UnityEngine;

public class GemPlaceholder : MonoBehaviour
{
    public event Action<bool> StatusChanged;
    public bool IsGemPlaced { get; private set; }
    public Gem Gem { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Gem gem))
            return;

        Gem = gem;
        IsGemPlaced = true;
        StatusChanged?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out Gem gem))
            return;

        Gem = null;
        IsGemPlaced = false;
        StatusChanged?.Invoke(false);
    }
}