using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardSelector<T> where T : ISelectable
{
    private readonly IReadOnlyList<T> _items;
    private readonly ScrollRect _scrollRect;
    private int _currentIndex;

    public T Current => _items.Count > 0 ? _items[_currentIndex] : default;
    public int CurrentIndex => _currentIndex;

    public KeyboardSelector(IReadOnlyList<T> items, ScrollRect scrollRect)
    {
        _items = items;
        _scrollRect = scrollRect;
    }

    public void Init()
    {
        _currentIndex = 0;

        if (_items.Count > 0)
        {
            _items[0].SetSelected(true);
        }
    }

    public void Tick()
    {
        if (_items.Count == 0) 
            return;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectIndex(_currentIndex + 1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectIndex(_currentIndex - 1);
        }
    }

    private void SelectIndex(int newIndex)
    {
        if (newIndex < 0 || newIndex >= _items.Count) 
            return;

        _items[_currentIndex].SetSelected(false);
        _currentIndex = newIndex;
        _items[_currentIndex].SetSelected(true);

        ScrollToCurrentItem();
    }

    private void ScrollToCurrentItem()
    {
        RectTransform itemRect = _items[_currentIndex].RectTransform;
        RectTransform contentRect = _scrollRect.content;
        RectTransform viewportRect = _scrollRect.viewport;

        float itemTop = -itemRect.anchoredPosition.y;
        float itemBottom = itemTop + itemRect.rect.height;

        float viewportHeight = viewportRect.rect.height;
        float contentOffset = contentRect.anchoredPosition.y;

        float visibleTop = contentOffset;
        float visibleBottom = contentOffset + viewportHeight;

        if (itemTop < visibleTop)
        {
            contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, itemTop);
        }
        else if (itemBottom > visibleBottom)
        {
            contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, itemBottom - viewportHeight);
        }
    }
}