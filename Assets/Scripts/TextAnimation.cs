using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextAnimation : MonoBehaviour
{
    [SerializeField] private float fadeDuration;

    private TextMeshProUGUI _text;
    private Color _sourceColor;

    public void Init() {
        _text = GetComponent<TextMeshProUGUI>();
        _sourceColor = _text.color;
        _text.color = Color.clear;
    }

    public void ResetAnimation() {
        _text.color = Color.clear;
    }

    public void ShowAnimation() {
        _text.color = Color.clear;
        var sequence = DOTween.Sequence();
        sequence.Append(_text.DOColor(_sourceColor, fadeDuration));
    }
}
