using UnityEngine;

public class SimonButton : MonoBehaviour
{
    [SerializeField] private MeshRenderer _button;
    [SerializeField] private Color _highlightColor;
    private Color _originalColor;

    private void Start()
    {
        _originalColor = _button.material.color;
    }

    public void TurnOn()
    {
        _button.material.color = _highlightColor;
    }

    public void TurnOff()
    {
        _button.material.color = _originalColor;
    }
}