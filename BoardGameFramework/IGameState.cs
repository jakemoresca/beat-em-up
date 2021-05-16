using BoardGameFramework.Dices;
using Godot;
using System;
using System.Collections.Generic;

namespace BoardGameFramework
{
    public interface IGameState
    {
        IDictionary<string, Unit> PlayerUnits { get; }
        RoundState RoundState { get; }
        DiceState DiceState { get; }
        IEnumerable<string> GamePhases { get; }
        string CurrentGamePhase { get; }
        IGameState Clone();
        List<int> PlayerTurnOrder { get; }
    }
}
