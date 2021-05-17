using BoardGameFramework.Dices;
using Godot;
using System;
using System.Collections.Generic;
using BoardGameFramework.Boards;

namespace BoardGameFramework
{
    public interface IGameState
    {
        IDictionary<string, BoardUnit> PlayerUnits { get; }
        RoundState RoundState { get; }
        DiceState DiceState { get; }
        IEnumerable<string> GamePhases { get; }
        string CurrentGamePhase { get; }
        IGameState Clone();
        List<int> PlayerTurnOrder { get; }
    }
}
