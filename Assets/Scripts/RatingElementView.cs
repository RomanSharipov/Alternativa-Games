using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RatingElementView : MonoBehaviour, ISelectable
{
    [SerializeField] private Image _selectionBorder;
    [SerializeField] private TMP_Text _header;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _userIcon;
    [SerializeField] private Button _expandButton;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private HeightAnimator _heightAnimator;
    

    private RatingElementData _data;
    private bool _isExpanded;

    public RectTransform RectTransform => _rectTransform;
    public bool IsExpanded => _isExpanded;

    public event Action<RatingElementView> OnClicked;

    private void Awake()
    {
        _expandButton.onClick.AddListener(HandleClick);
    }

    private void OnDestroy()
    {
        _expandButton.onClick.RemoveListener(HandleClick);
    }

    private void HandleClick()
    {
        OnClicked?.Invoke(this);
        Toggle();
    }
    
    public void SetSelected(bool isSelected)
    {
        _selectionBorder.gameObject.SetActive(isSelected);
    }

    public void Init(RatingElementData data)
    {
        _data = data;
        _header.SetText(_data.Header);
        _description.SetText(_data.Description);
        _userIcon.sprite = _data.Icon;
    }

    public void Toggle()
    {
        _isExpanded = !_isExpanded;

        if (_isExpanded)
        {
            _heightAnimator.Expand();
        }
        else
        {
            _heightAnimator.Collapse();
        }
    }
}