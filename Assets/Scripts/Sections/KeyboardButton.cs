using TMPro;
using UnityEngine;

public class KeyboardButton : MonoBehaviour
{
    [SerializeField] private MeshRenderer _indicator;
    [SerializeField] private TextMeshPro _text;
    public char Symbol
    {
        get => _text.text[0];
        set => _text.text = $"{value}";
    }

    public void Click()
    {
        _indicator.material.color = Color.green;
    }
}