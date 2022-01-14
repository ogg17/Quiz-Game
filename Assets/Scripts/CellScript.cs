using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CellScript : MonoBehaviour, IPointerClickHandler {

    [SerializeField] private Image cellImage;
    [SerializeField] private RectTransform cellImageRectTransform;
    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private CellAnimation cellAnimation;
    public CellGameController GameController { get; set; }
    public CellAnimation CellAnimation => cellAnimation;
    public bool IsWinCell { get; set; }
    public CellOptions CellOption { get; private set; }

    public void SetImage(Sprite image) => cellImage.sprite = image;

    private bool _isClicked = false;
    
    public void SetParameter(CellOptions cellOption) {
        CellOption = cellOption;
        cellImageRectTransform.Translate(cellOption.CellLocalPosition);
        cellImageRectTransform.localEulerAngles = cellOption.CellLocalRotation;
        cellImageRectTransform.localScale = cellOption.CellLocalScale != Vector2.zero ? cellOption.CellLocalScale : Vector2.one;
    }
    
    public void OnPointerClick(PointerEventData eventData) {
        if (IsWinCell && !_isClicked) {
            particleSystem.Play();
            GameController.GameWin();
            _isClicked = true;
        }
        else if (!_isClicked) {
            _isClicked = true;
            cellAnimation.EaseInBounceAnimation().OnComplete(() => _isClicked = false);
        }
    }
}
