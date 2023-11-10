using UnityEngine;

public class KeyboardButton : MonoBehaviour
{
    [SerializeField] private MeshRenderer _indicator;

    public void Click()
    {
        _indicator.material.color = Color.green;
    }
}