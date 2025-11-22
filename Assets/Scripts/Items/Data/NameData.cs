using UnityEngine;

[System.Serializable]
public class NameData
{
    
    [SerializeField] private string displayName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    
    public string DisplayName { get => displayName; private set => displayName = value; }
    public string Description { get => description; private set => description = value; }
    public Sprite Icon { get => icon; private set => icon = value; }
}

[System.Serializable]
public class StatData
{
    [SerializeField] private int damage;
}
