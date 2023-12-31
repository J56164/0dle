using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    private Player player;
    private Level level;
    private Dictionary<string, Currency> nameToCurrencies;
    private List<int> upgradeAmounts;
    private Dictionary<string, List<Effect>> effects;

    // Start is called before the first frame update
    void Start()
    {
        InitCurrencies();
        InitPlayerAmounts();
        ClearUpgradeAmounts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitCurrencies() {
        foreach (Currency currency in level.currencies) {
            nameToCurrencies[currency.name] = currency;
            foreach (Effect currencyEffects in currency.effects) {
                effects[currency.name].Add(currencyEffects);
            }
        }
    }

    void InitPlayerAmounts() {
        foreach (Init init in level.inits) {
            string currencyName = init.name;
            player.amounts[init.name] = init.amount;
        }
    }

    void InitUpgradeAmounts() {
        upgradeAmounts = new List<int>(level.upgrades.Count);
        ClearUpgradeAmounts();
    }

    void ClearUpgradeAmounts() {
        for (int upgradeIndex = 0; upgradeIndex < level.upgrades.Count; upgradeIndex++) {
            upgradeAmounts[upgradeIndex] = 0;
        }
    }

    void UpdateTurn() {

        Dictionary<string, int> prevAmounts = new Dictionary<string, int>(player.amounts);
        for (int upgradeIndex = 0; upgradeIndex < level.upgrades.Count; upgradeIndex++) {
            Upgrade upgrade = level.upgrades[upgradeIndex];
            foreach (Effect effect in upgrade.effects) {
                String targetCurrencyName = effect.name;
                int amount = upgradeAmounts[upgradeIndex];
                player.amounts[targetCurrencyName] += amount * effect.increment;
            }
        }
        foreach (KeyValuePair<string, List<Effect>> keyValue in effects) {
            String currencyName = keyValue.Key;
            List<Effect> currencyEffects = keyValue.Value;
            foreach (Effect effect in currencyEffects) {
                String targetCurrencyName = effect.name;
                player.amounts[targetCurrencyName] += prevAmounts[currencyName] * effect.increment;
            }
        }
        if (CheckObjectives()) {
            WinLevel();
        }
    }

    bool CheckObjectives() {
        foreach (Objective objective in level.objectives) {
            if (CheckObjective(objective)) {
                return true;
            }
        }
        return false;
    }

    bool CheckObjective(Objective objective) {
        foreach (Requirement requirement in objective.requirements) {
            if (CheckRequirement(requirement)) {
                return true;
            }
            foreach (Objective subObjective in objective.subObjectives) {
                if (CheckObjective(subObjective)) {
                    return true;
                }
            }
        }
        return false;
    }

    bool CheckRequirement(Requirement requirement) {
        if (player.amounts[requirement.name] >= requirement.range.ge) {
            return true;
        } else {
            return false;
        }
    }

    void WinLevel() {
        
    }
}
