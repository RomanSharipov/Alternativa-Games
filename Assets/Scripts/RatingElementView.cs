using System;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class RatingElementView : MonoBehaviour, ISelectable
{
    [SerializeField] private Image _selectionBorder;
    [SerializeField] private TMP_Text _header;
    [SerializeField] private Image _userIcon;

    [SerializeField] private RectTransform _rectTransform;
    private RatingElementData _data;

    public RectTransform RectTransform => _rectTransform;

    public void SetSelected(bool isSelected)
    {
        _selectionBorder.enabled = isSelected;
    }

    public void Init(RatingElementData data)
    {
        _data = data;
        _header.SetText(_data.Header);
        _userIcon.sprite = _data.Icon;
    }
}