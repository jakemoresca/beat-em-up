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

		public void StartBoardGame(IGameState gameState)
		{
			_gameState = gameState;

			_actionManager = new ActionManager(UpdateState);
			_diceManager = new DiceManager(_actionManager);
		}

		public void RegisterAction(BaseAction action)
		{
			_actionManager.RegisterAction(action);
		}

		private IGameState UpdateState(IGameState newState)
		{
			_gameState = newState;
			return _gameState;
		}

		public IGameState GetState() => _gameState;
		public ActionManager GetActionManager() => _actionManager;
		public DiceManager GetDiceManager() => _diceManager;
	}
}
