using System.Collections.Generic;
using BoardGameFramework.Dices;

namespace BoardGameFramework
{
	public class GameState : IGameState
	{
		private RoundState _roundState;
		private IDictionary<string, Unit> _playerUnits;

		public GameState() : this( 
			new Dictionary<string, Unit>(), 
			new RoundState(0, 0), 
			"GAME_START", 
			new DiceState(new Dictionary<string, DiceData>(), string.Empty, DicePhase.Hidden, string.Empty)) {}

		public GameState(IDictionary<string, Unit> playerUnits, RoundState roundState, string currentGamePhase, DiceState diceState)
		{
			_playerUnits = playerUnits;
			_roundState = roundState;
			CurrentGamePhase = currentGamePhase;
		}

		public IDictionary<string, Unit> PlayerUnits => _playerUnits;
		public RoundState RoundState => _roundState;

		public IEnumerable<string> GamePhases => new List<string>
		{
			"GAME_START"
		};

		public string CurrentGamePhase { get; }

		public DiceState DiceState { get; }

		public virtual IGameState Clone()
		{
			return new GameState(_playerUnits, _roundState, CurrentGamePhase, DiceState.Clone());
		}
	}
}
