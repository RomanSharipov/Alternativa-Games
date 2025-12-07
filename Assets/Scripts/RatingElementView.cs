using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class RatingElementView : MonoBehaviour, ISelectable
{
    [SerializeField] private Image _selectionBorder;

    [SerializeField] private RectTransform _rectTransform;

    public RectTransform RectTransform => _rectTransform;

    public void SetSelected(bool isSelected)
    {
        _selectionBorder.enabled = isSelected;
    }
}