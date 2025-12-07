using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicListController : MonoBehaviour
{
    [SerializeField] private RatingElementsDatabase _ratingElementsDatabase;

    [SerializeField] private Transform _elementsContainer;
    [SerializeField] private RatingElementView _ratingElementViewPrefab;

    private void Start()
    {
        foreach (RatingElementData element in _ratingElementsDatabase.AllElements)
        {
            RatingElementView ratingElementView = Instantiate(_ratingElementViewPrefab, _elementsContainer);

            ratingElementView.transform.localScale = Vector3.one;



        }
    }


}
