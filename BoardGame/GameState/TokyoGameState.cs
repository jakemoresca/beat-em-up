using System.Collections.Generic;
using BoardGameFramework;
using BoardGameFramework.Dices;
using BoardGameFramework.Boards;

namespace ProjectTokyo
{
    public class TokyoGameState : GameState
    {
        public static TokyoGameState Create()
        { 
			var turnDice = new DiceData("TurnDice", "res://BoardGame/Dice/DiceDisplay.tscn", 
				new [] { "Attack", "Energy", "Health" }, 
				new [] {0, 0, 0}, 
				new [] { "res://BoardGame/Dice/bite.png", "res://BoardGame/Dice/miss.png", "res://BoardGame/Dice/ok.svg" }, 
				3);

			var diceDictionary = new Dictionary<string, DiceData>
			{
				{ "TurnDice", turnDice }
			};

			var diceState = new DiceState(diceDictionary, string.Empty, DicePhase.Hidden, string.Empty);

			return new TokyoGameState(new Dictionary<string, BoardUnit>(), new RoundState(0, 1), string.Empty, diceState, 1, 0);
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
