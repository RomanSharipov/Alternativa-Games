using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeightAnimator : MonoBehaviour
{
    [SerializeField] private RectTransform _targetRect;
    [SerializeField] private float _expandedHeight = 150f;
    [SerializeField] private float _animationDuration = 0.3f;

    private float _collapsedHeight;
    private Coroutine _currentAnimation;
    private RectTransform _parentRect;
    
    private void Awake()
    {
        _collapsedHeight = _targetRect.sizeDelta.y;
        _parentRect = _targetRect.parent as RectTransform;
    }

    public void Expand()
    {
        StartAnimation(_expandedHeight);
    }

    public void Collapse()
    {
        StartAnimation(_collapsedHeight);
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
        float startHeight = _targetRect.sizeDelta.y;
        float elapsed = 0f;

        while (elapsed < _animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / _animationDuration;

            float newHeight = Mathf.Lerp(startHeight, targetHeight, t);
            _targetRect.sizeDelta = new Vector2(_targetRect.sizeDelta.x, newHeight);

            RebuildLayout();

            yield return null;
        }

        _targetRect.sizeDelta = new Vector2(_targetRect.sizeDelta.x, targetHeight);
        RebuildLayout();

        _currentAnimation = null;
    }

    private void RebuildLayout()
    {
        if (_parentRect != null)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_parentRect);
        }
    }
}