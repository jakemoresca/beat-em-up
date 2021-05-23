using System.Collections.Generic;
using System.Linq;

namespace BoardGameFramework.Dices
{
    public class DiceState
    {
        public DiceState(IDictionary<string, DiceData> dicesData, string currentDice, DicePhase currentDicePhase, string rolledValue)
        {
            DicesData = dicesData;
            CurrentDice = currentDice;
            CurrentDicePhase = currentDicePhase;
            RolledValue = rolledValue;
        }

        public IDictionary<string, DiceData> DicesData { get; }
        public string CurrentDice { get; }
        public DicePhase CurrentDicePhase { get; }
        public string RolledValue { get; }

        public DiceState Clone()
        {
            var dicesData = DicesData.ToDictionary(entry => entry.Key, entry => entry.Value);

            return new DiceState(dicesData, CurrentDice, CurrentDicePhase, RolledValue);
        }
    }

    public class DiceData
    {
        public DiceData(string name, string dicePath, string[] diceNames, int[] diceArtAngles, string[] diceArts, int diceInstances = 1)
        {
            Name = name;
            DicePath = dicePath;
            DiceNames = diceNames;
            DiceArtAngles = diceArtAngles;
            DiceArts = diceArts;
            DiceInstances = diceInstances;
        }

        public string Name { get; }
        public string DicePath { get; }
        public string[] DiceNames { get; }
        public int[] DiceArtAngles { get; }
        public string[] DiceArts { get; }
        public int DiceInstances { get; }
    }

    public enum DicePhase
    {
        Hidden,
        Shown,
        Rolling,
        Rolled,
        Hiding
    }
}