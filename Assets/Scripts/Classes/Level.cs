using System.Collections.Generic;

[System.Serializable]
public class Level
{
    public string name;
    public List<Currency> currencies;
    public List<Init> inits;
    public List<Upgrade> upgrades;
    public List<Objective> objectives;
}