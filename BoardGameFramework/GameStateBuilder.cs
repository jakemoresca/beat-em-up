using System;
using System.Collections.Generic;
using BoardGameFramework.Dices;

namespace BoardGameFramework
{
    public class GameStateBuilder
    {
        private readonly Func<IGameState> _getStateAction;

        public GameStateBuilder(Func<IGameState> getStateAction)
        {
            _getStateAction = getStateAction;
        }

        private IDictionary<string, Unit> PlayerUnits { get; set; }
        private RoundState RoundState { get; set; }
        private IEnumerable<string> GamePhases { get; set; }
        private string CurrentGamePhase { get; set; }
        private DiceState DiceState { get; set; }
        private int CurrentPlayerNumber { get; set; }

        public GameStateBuilder Initialize()
        {
            var state = _getStateAction();

            PlayerUnits = state.PlayerUnits;
            RoundState = state.RoundState;
            GamePhases = state.GamePhases;
            CurrentGamePhase = state.CurrentGamePhase;
            DiceState = state.DiceState;

            return this;
        }

        public GameStateBuilder SetDiceState(DiceState diceState)
        {
            DiceState = diceState;

            return this;
        }

        public IGameState Build() => new GameState(PlayerUnits, RoundState, CurrentGamePhase,
            DiceState, CurrentPlayerNumber);
    }
}