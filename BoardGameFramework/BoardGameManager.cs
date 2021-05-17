using System;
using System.Collections.Generic;
using BoardGameFramework.Actions;
using BoardGameFramework.Dices;
using Godot;

namespace BoardGameFramework
{
	//AutoLoad
	public class BoardGameManager : Node
	{
		private IGameState _gameState;
		private ActionManager _actionManager;
		private DiceManager _diceManager;
		private GameStateBuilder _gameStateBuilder;
		private IDictionary<string, Func<IGameState, Action>> _stateListeners;

		public void StartBoardGame(IGameState gameState)
		{
			_gameState = gameState;

			_actionManager = new ActionManager(UpdateState);
			_diceManager = new DiceManager(_actionManager, this);
			_gameStateBuilder = new GameStateBuilder(GetState);

			_stateListeners = new Dictionary<string, Func<IGameState, Action>>();
		}

		public void RegisterAction(BaseAction action)
		{
			_actionManager.RegisterAction(action);
		}

		public void RegisterListener(string name, Func<IGameState, Action> listener)
		{
			if(!_stateListeners.TryAdd(name, listener))
				throw new InvalidOperationException("Key exist for listener: " + name);
		}

		public void UnregisterListener(string name)
		{
			_stateListeners.Remove(name);
		}

		private IGameState UpdateState(IGameState newState)
		{
			_gameState = newState;
			
			return _gameState;
		}

		public IGameState GetState() => _gameState;
		public ActionManager GetActionManager() => _actionManager;
		public DiceManager GetDiceManager() => _diceManager;
		public GameStateBuilder GetGameStateBuilder() => _gameStateBuilder;

		private void NotifyListeners()
		{
			foreach (var listener in _stateListeners.Values)
			{
				listener(_gameState);
			}
		}
	}
}
