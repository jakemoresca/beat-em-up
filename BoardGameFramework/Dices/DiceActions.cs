using BoardGameFramework.Actions;
using Godot;
using System;
using System.Collections.Generic;

namespace BoardGameFramework.Dices
{
    public static class DiceActions
    {
        public static List<KeyValuePair<string, BaseAction>> GetDiceActions(BoardGameManager boardGameManager)
        {
            return new List<KeyValuePair<string, BaseAction>>
            {
                new KeyValuePair<string, BaseAction>(BaseActionNames.RollDice, new BaseAction(BaseActionNames.RollDice, boardGameManager, RollDiceAction))
            };
        }

        public static IGameState RollDiceAction(SimpleValue[] simpleValues, Func<IGameState> getState, Func<GameStateBuilder> getGameStateBuilder)
        {
            var state = getState();
            var gameStateBuilder = getGameStateBuilder();

            var diceState = state.DiceState;

            var newDiceState = new DiceState(diceState.DicesData, diceState.CurrentDice, DicePhase.Rolling, diceState.RolledValue);

            var newState = gameStateBuilder.Initialize()
                .SetDiceState(newDiceState)
                .Build();

            return newState;
        }
    }

    public class RollDiceAction
    {
        
    }
}