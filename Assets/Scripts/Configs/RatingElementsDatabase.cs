using UnityEngine;

[CreateAssetMenu(menuName = "DynamicListTestTask/RatingElementsDatabase", fileName = "RatingElementsDatabase")]
public class RatingElementsDatabase : ScriptableObject
{
    [SerializeField] private RatingElementData[] _allElements;

    public RatingElementData[] AllElements => _allElements;

}
