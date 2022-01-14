using UnityEngine;
using DG.Tweening;

public class CellAnimation : MonoBehaviour {
    [SerializeField] private float bounceDuration;
    [SerializeField] private float bounceScale;
    [SerializeField] private float easeInBounceDistance;
    [SerializeField] private float easeInBounceDuration;
    [SerializeField] private RectTransform cellObjectRectTransform;
    
    private Sequence _sequence;

    public void SequenceInit() {
        _sequence = DOTween.Sequence();
    }
    public void ResetAnimation() {
        cellObjectRectTransform.localScale = Vector3.zero;
    }
    
    public void BounceAnimationStart(Vector3 lastScale) {
        _sequence = DOTween.Sequence();
        var cellObjectTransform = cellObjectRectTransform;
        _sequence.Append(cellObjectTransform.DOScale(lastScale * bounceScale, bounceDuration));
        _sequence.Append(cellObjectTransform.DOScale(lastScale, bounceDuration / 5));
    }

    public Sequence WinBounceAnimation(Vector3 lastScale) {
        _sequence = DOTween.Sequence();
        var cellObjectTransform = cellObjectRectTransform;
        _sequence.Append(cellObjectTransform.DOScale(lastScale * bounceScale, bounceDuration / 2));
        _sequence.Append(cellObjectTransform.DOScale(Vector3.zero, bounceDuration));
        return _sequence;
    }

    public Sequence EaseInBounceAnimation() {
        _sequence = DOTween.Sequence();
        var cellObjectTransform = cellObjectRectTransform;
        var startPositionX = cellObjectTransform.position.x;
        for (var x = 0.1f; x <= 1; x += 0.1f){
            _sequence.Append(cellObjectTransform.DOMoveX(
                startPositionX + easeInBounceDistance * EaseBounce.EaseInBounce(x),
                easeInBounceDuration));
            _sequence.Append(cellObjectTransform.DOMoveX(
                startPositionX - easeInBounceDistance * EaseBounce.EaseInBounce(x),
                easeInBounceDuration));
        }
        _sequence.Append(cellObjectTransform.DOMoveX(startPositionX, easeInBounceDuration));
        return _sequence;
    }

    public void KillAnimation() {
        _sequence.Kill();
    }
}
