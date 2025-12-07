using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicListController : MonoBehaviour
{
    [SerializeField] private RatingElementsDatabase _ratingElementsDatabase;
    [SerializeField] private Transform _elementsContainer;
    [SerializeField] private RatingElementView _ratingElementViewPrefab;
    [SerializeField] private ScrollRect _scrollRect;

    [SerializeField] private List<RatingElementView> _elements = new List<RatingElementView>();
    private KeyboardSelector<RatingElementView> _selector;

    private void Start()
    {
        CreateElements();
        _selector = new KeyboardSelector<RatingElementView>(_elements, _scrollRect);
        _selector.Init();
    }

    private void Update()
    {
        _selector.Tick();
    }

    private void CreateElements()
    {
        foreach (RatingElementData data in _ratingElementsDatabase.AllElements)
        {
            RatingElementView view = Instantiate(_ratingElementViewPrefab, _elementsContainer);
            view.transform.localScale = Vector3.one;
            view.Init(data);
            view.OnClicked += OnElementClicked;
            _elements.Add(view);
        }
    }

    private void OnElementClicked(RatingElementView view)
    {
        _selector.SelectByItem(view);
    }

    private void OnDestroy()
    {
        foreach (var view in _elements)
        {
            view.OnClicked -= OnElementClicked;
        }
    }
}