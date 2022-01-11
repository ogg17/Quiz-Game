using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CellScript : MonoBehaviour, IPointerClickHandler {
    
    private Image _image;
    
    void Start() {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData) {
        throw new System.NotImplementedException();
    }

    public void SetRandomImage() {
        
    }
}
