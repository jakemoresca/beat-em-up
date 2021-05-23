using BoardGameFramework.Actions;
using Godot;
using System;
using System.Collections.Generic;

namespace BoardGameFramework.Dices
{
	public static class DiceActions
	{
		private static RandomNumberGenerator _random;

		public static List<BaseAction> GetDiceActions(BoardGameManager boardGameManager)
		{
			_random = new RandomNumberGenerator();
			_random.Randomize();

			return new List<BaseAction>
			{
				new BaseAction(BaseActionNames.RollDice, boardGameManager, RollDiceAction),
				new BaseAction(BaseActionNames.ShowDice, boardGameManager, ShowDiceAction),
				new BaseAction(BaseActionNames.AddDice, boardGameManager, AddDiceAction),
				new BaseAction(BaseActionNames.HideDice, boardGameManager, HideAction),
				new BaseAction(BaseActionNames.SetRandomValue, boardGameManager, SetDiceRandomValueAction),
			};
		}

		private static IGameState RollDiceAction(SimpleValue[] simpleValues, Func<IGameState> getState, Func<GameStateBuilder> getGameStateBuilder)
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

		private static IGameState ShowDiceAction(SimpleValue[] simpleValues, Func<IGameState> getState, Func<GameStateBuilder> getGameStateBuilder)
		{
			var state = getState();
			var gameStateBuilder = getGameStateBuilder();
			var diceState = state.DiceState;
			var diceName = simpleValues[0].ValueAsString();

			var newDiceState = new DiceState(diceState.DicesData, (string)diceName, DicePhase.Shown, diceState.RolledValue);

			var newState = gameStateBuilder.Initialize()
				.SetDiceState(newDiceState)
				.Build();

			return newState;
		}

		private static IGameState AddDiceAction(SimpleValue[] simpleValues, Func<IGameState> getState, Func<GameStateBuilder> getGameStateBuilder)
		{
			var state = getState();
			var gameStateBuilder = getGameStateBuilder();
			var diceState = state.DiceState;

			var diceName = simpleValues[0].ValueAsString();
			var dicePath = simpleValues[1].ValueAsString();
			var diceNames = (string[])simpleValues[2].ValueAsStringArray();
			var diceArtAngles = (int[])simpleValues[3].ValueAsNumberArray();
			var diceArts = (string[])simpleValues[4].ValueAsStringArray();
			var diceInstances = simpleValues[5].ValueAsNumber();

			var dicesData = diceState.DicesData;
			dicesData.Add(diceName, new DiceData(diceName, dicePath, diceNames, diceArtAngles, diceArts, diceInstances));

			var newDiceState = new DiceState(dicesData, diceState.CurrentDice, diceState.CurrentDicePhase, diceState.RolledValue);

			var newState = gameStateBuilder.Initialize()
				.SetDiceState(newDiceState)
				.Build();

			return newState;
		}

		private static IGameState HideAction(SimpleValue[] simpleValues, Func<IGameState> getState, Func<GameStateBuilder> getGameStateBuilder)
		{
			var state = getState();
			var gameStateBuilder = getGameStateBuilder();

			var diceState = state.DiceState;

			var newDiceState = new DiceState(diceState.DicesData, diceState.CurrentDice, DicePhase.Hidden, diceState.RolledValue);

			var newState = gameStateBuilder.Initialize()
				.SetDiceState(newDiceState)
				.Build();

			return newState;
		}

		private static IGameState SetDiceRandomValueAction(SimpleValue[] simpleValues, Func<IGameState> getState, Func<GameStateBuilder> getGameStateBuilder)
		{
			var state = getState();
			var gameStateBuilder = getGameStateBuilder();

			var diceState = state.DiceState;

			if(!diceState.DicesData.TryGetValue(diceState.CurrentDice, out var diceData))
				throw new InvalidOperationException($"No dice registered with that name: {diceState.CurrentDice}");

			var selectedIndex = _random.Randi() % diceData.DiceNames.Length;
			var rolledValue = diceData.DiceNames[selectedIndex];

			var newDiceState = new DiceState(diceState.DicesData, diceState.CurrentDice, DicePhase.Hiding, rolledValue);

			var newState = gameStateBuilder.Initialize()
				.SetDiceState(newDiceState)
				.Build();

			return newState;
		}
	}
}
