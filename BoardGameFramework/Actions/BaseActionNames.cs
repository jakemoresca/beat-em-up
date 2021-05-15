using System;

namespace BoardGameFramework.Actions
{
    public static class BaseActionNames
    {
        private static string BasePrefix => "BoardGameFramework";
        public static string RollDice => $"{BasePrefix}_ROLL_DICE";
        public static string ShowDice => $"{BasePrefix}_SHOW_DICE";
        public static string AddDice => $"{BasePrefix}_ADD_DICE";
        public static string SetRandomValue => $"{BasePrefix}_SET_RANDOM_DICE_VALUE";
        public static string HideDice => $"{BasePrefix}_HIDE_DICE";
    }
}