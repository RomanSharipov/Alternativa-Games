using UnityEngine;

public interface ISelectable
{
    public RectTransform RectTransform { get; }
    public void SetSelected(bool isSelected);
}