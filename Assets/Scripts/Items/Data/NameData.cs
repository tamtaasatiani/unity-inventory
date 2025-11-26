using UnityEngine;
using BetterAttributes;

[System.Serializable]
public class NameData
{
    [SerializeField, BetterIcon] private Sprite icon;
    [SerializeField] private string displayName;
    [SerializeField] private string description;
    
    public string DisplayName { get => displayName; private set => displayName = value; }
    public string Description { get => description; private set => description = value; }
    public Sprite Icon { get => icon; private set => icon = value; }
}

[System.Serializable]
public class StatData
{
    [SerializeField, BetterSlider(Constants.MIN_DAMAGE, Constants.MAX_DAMAGE)] private int damage;
}
