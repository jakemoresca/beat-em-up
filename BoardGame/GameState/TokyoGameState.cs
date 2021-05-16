using System.Collections.Generic;
using BoardGameFramework;
using BoardGameFramework.Dices;

namespace ProjectTokyo
{
    public class TokyoGameState : GameState
    {
        public TokyoGameState() : base()
        { 
			Score = 0;
		}

		public TokyoGameState(IDictionary<string, Unit> playerUnits, 
			RoundState roundState, 
			string currentGamePhase, 
			DiceState diceState,
			int score) : base(playerUnits, roundState, currentGamePhase, diceState)
		{
			Score = score; 
		}

        public int Score { get; } //Test state

		public override IGameState Clone()
		{
			return new TokyoGameState(PlayerUnits, RoundState, CurrentGamePhase, DiceState, Score);
		}
    }
}
