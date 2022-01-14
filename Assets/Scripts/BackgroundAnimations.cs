using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BackgroundAnimations : MonoBehaviour {
    [SerializeField] private float fadeDuration;
    [SerializeField] private float delayHideAnimationDuration;
    
    private Image _image;
    private Color _sourceColor;

    public void Init() {
        _image = GetComponent<Image>();
        _sourceColor = _image.color;
        _image.color = Color.clear;
    }

    public Sequence ShowAnimation() {
        var sequence = DOTween.Sequence();
        sequence.Append(_image.DOColor(_sourceColor, fadeDuration));
        return sequence;
    }
    
    public Sequence HideAnimation() {
        var sequence = DOTween.Sequence();
        sequence.Append(_image.DOColor(Color.clear, fadeDuration));
        return sequence;
    }

    public Sequence DelayHideAnimation() {
        _image.color = _sourceColor;
        var sequence = DOTween.Sequence();
        sequence.AppendInterval(delayHideAnimationDuration);
        sequence.Append(_image.DOColor(Color.clear, fadeDuration));
        return sequence;
    }
}
