using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeightAnimator : MonoBehaviour
{
    [SerializeField] private RectTransform _targetRect;
    [SerializeField] private LayoutElement _layoutElement;
    [SerializeField] private float _expandedHeight = 150f;
    [SerializeField] private float _animationDuration = 0.3f;

    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private float _padding = 20f;

    private float _collapsedHeight;
    private Coroutine _currentAnimation;

    
    private void Awake()
    {
        _collapsedHeight = _targetRect.sizeDelta.y;
    }

    public void Expand()
    {
        float expandedHeight = CalculateExpandedHeight();
        StartAnimation(expandedHeight);
    }

    public void Collapse()
    {
        StartAnimation(_collapsedHeight);
    }

    private float CalculateExpandedHeight()
    {
        return _collapsedHeight + _descriptionText.preferredHeight + _padding;
    }

    private void StartAnimation(float targetHeight)
    {
        if (_currentAnimation != null)
        {
            StopCoroutine(_currentAnimation);
        }
        _currentAnimation = StartCoroutine(AnimateHeight(targetHeight));
    }

    private IEnumerator AnimateHeight(float targetHeight)
    {
        float startHeight = _layoutElement.preferredHeight;
        float elapsed = 0f;

        while (elapsed < _animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / _animationDuration;

            _layoutElement.preferredHeight = Mathf.Lerp(startHeight, targetHeight, t);

            yield return null;
        }

        _layoutElement.preferredHeight = targetHeight;
        _currentAnimation = null;
    }


}