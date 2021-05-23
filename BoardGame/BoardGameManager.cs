using Godot;
using System;
using FrameworkBoardGameManager = BoardGameFramework.BoardGameManager;

namespace ProjectTokyo
{
	public class BoardGameManager : Node2D
	{
		// Declare member variables here. Examples:
		private FrameworkBoardGameManager _gameManager;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			var gameState = TokyoGameState.Create();
			_gameManager = (FrameworkBoardGameManager)GetNode("/root/FrameworkBoardGameManager");
			_gameManager.StartBoardGame(gameState);

			var diceManager = _gameManager.GetDiceManager();
			diceManager.ShowDice("TurnDice");
		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	}
}
