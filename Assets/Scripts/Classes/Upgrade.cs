using System.Collections.Generic;

[System.Serializable]
public class Upgrade
{
    public string name;
    public List<Effect> effects;
    public List<Requirement> requirements;
}