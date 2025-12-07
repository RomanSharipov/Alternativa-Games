using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DynamicListTestTask/RatingElementData", fileName = "RatingElementData")]
public class RatingElementData : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private string _header;
    [SerializeField] private Sprite _icon;

    public string Id => _id;
    public string Header => _header;
    public Sprite Icon => _icon;
}
