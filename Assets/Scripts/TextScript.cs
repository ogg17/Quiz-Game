using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextScript : MonoBehaviour {
    private TextMeshProUGUI _text;

    public void Init() {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string newText) {
        if(_text != null) _text.text = newText;
    }
}
