using System.Collections.Generic;
using BoardGameFramework;
using BoardGameFramework.Dices;

namespace ProjectTokyo
{
	public class GameState : IGameState
	{
		private RoundState _roundState;
		private IDictionary<string, Unit> _playerUnits;

		public GameState()
		{
			_roundState = new RoundState(0, 0);
			_playerUnits = new Dictionary<string, Unit>();
		}

		public IDictionary<string, Unit> PlayerUnits => _playerUnits;
		public RoundState RoundState => _roundState;

		public IEnumerable<string> GamePhases => new List<string>
		{
			"GAME_START"
		};

		public string CurrentGamePhase => "GAME_START";

        public DiceState DiceState => new DiceState(new Dictionary<string, DiceData>(), string.Empty, DicePhase.Hidden, string.Empty);
    }
}