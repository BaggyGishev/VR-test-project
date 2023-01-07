using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class SummoningCircle : MonoBehaviour
{
    [SerializeField] private GemPlaceholder[] placeholders;
    [SerializeField] private GameObject summoningVFXObject;
    [SerializeField] private GameObject npcObject;

    [SerializeField] private AudioClip transformationClip;

    private AudioSource _audioSource;
    private bool _isSummoned;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
        _isSummoned = true;

        await Task.Delay(1500);
        _audioSource.PlayOneShot(transformationClip);
        summoningVFXObject.SetActive(true);
        await Task.Delay(500);
        foreach (var placeholder in placeholders) Destroy(placeholder.Gem.gameObject);
        npcObject.SetActive(true);
    }
}