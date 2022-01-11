using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CellScript : MonoBehaviour, IPointerClickHandler {
    [SerializeField] private GameEvents events;

    private Image _image;
    private bool _isWinCell;

    void Start() {
        _image = GetComponent<Image>();
    }
    
    public void SetImage(Sprite image) => _image.sprite = image;

    public void SetTransform(CellParameters cellParameter) {
        Transform tmpTransform;
        (tmpTransform = transform).Translate(cellParameter.CellLocalPosition);
        tmpTransform.localEulerAngles = cellParameter.CellLocalRotation;
        tmpTransform.localScale = cellParameter.CellLocalScale != Vector2.zero ? cellParameter.CellLocalScale : Vector2.one;
    }
    
    public void OnPointerClick(PointerEventData eventData) {
        
    }
    public void CellClick() {}
}
