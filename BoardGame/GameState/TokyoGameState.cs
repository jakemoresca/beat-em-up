using System.Collections.Generic;
using BoardGameFramework;
using BoardGameFramework.Dices;
using BoardGameFramework.Boards;

namespace ProjectTokyo
{
    public class TokyoGameState : GameState
    {
        public TokyoGameState() : base()
        { 
			Score = 0;
		}

		public TokyoGameState(IDictionary<string, BoardUnit> playerUnits, 
			RoundState roundState, 
			string currentGamePhase, 
			DiceState diceState,
			int currentPlayerNumber,
			int score) : base(playerUnits, roundState, currentGamePhase, diceState, currentPlayerNumber)
		{
			Score = score; 
		}

        public int Score { get; } //Test state

		public override IGameState Clone()
		{
			return new TokyoGameState(PlayerUnits, RoundState, CurrentGamePhase, DiceState, CurrentPlayerNumber, Score);
		}
    }
}
