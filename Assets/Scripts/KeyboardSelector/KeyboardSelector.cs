using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardSelector<T> where T : class, ISelectable
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

    public void SelectByItem(T item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] == item)
            {
                SelectIndex(i);
                return;
            }
        }
    }

    public void Tick()
    {
        if (_items.Count == 0) return;

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

        if (newIndex == _currentIndex) 
            return;

        _items[_currentIndex].SetSelected(false);
        _currentIndex = newIndex;
        _items[_currentIndex].SetSelected(true);

        ScrollToCurrentItem();
    }

    private void ScrollToCurrentItem()
    {
        Canvas.ForceUpdateCanvases();

        RectTransform itemRect = _items[_currentIndex].RectTransform;
        RectTransform contentRect = _scrollRect.content;
        RectTransform viewportRect = _scrollRect.viewport;

        float contentHeight = contentRect.rect.height;
        float viewportHeight = viewportRect.rect.height;

        if (contentHeight <= viewportHeight) return;

        float itemPositionY = Mathf.Abs(itemRect.anchoredPosition.y);
        float itemHeight = itemRect.rect.height;

        float targetPosition = itemPositionY - (viewportHeight / 2) + (itemHeight / 2);

        float maxScroll = contentHeight - viewportHeight;
        targetPosition = Mathf.Clamp(targetPosition, 0, maxScroll);

        float normalizedPosition = 1f - (targetPosition / maxScroll);

        _scrollRect.verticalNormalizedPosition = normalizedPosition;
    }


}