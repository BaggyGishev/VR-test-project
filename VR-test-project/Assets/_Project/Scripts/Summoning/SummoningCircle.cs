using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class SummoningCircle : MonoBehaviour
{
    [SerializeField] private GemPlaceholder[] placeholders;
    [SerializeField] private GameObject summoningVFXObject;
    
    private bool _isSummoned;

    private void OnEnable()
    {
        foreach (var placeholder in placeholders)
            placeholder.StatusChanged += OnPlaceholderStatusChanged;
    }

    private void OnDisable()
    {
        foreach (var placeholder in placeholders)
            placeholder.StatusChanged -= OnPlaceholderStatusChanged;
    }

    private void OnPlaceholderStatusChanged(bool val)
    {
        if (_isSummoned || placeholders.Any(x => !x.IsGemPlaced))
            return;

        Summon();
    }

    private async void Summon()
    {
        await Task.Delay(1500);
        Debug.Log("Summon");
        summoningVFXObject.SetActive(true);
        _isSummoned = true;
    }
}