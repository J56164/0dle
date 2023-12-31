using System.Collections.Generic;

[System.Serializable]
public class Objective
{
    public string name;
    public List<Requirement> requirements;
    public List<Objective> subObjectives;
}