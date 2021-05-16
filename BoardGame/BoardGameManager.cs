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
			var gameState = new TokyoGameState();
			_gameManager = (FrameworkBoardGameManager)GetNode("/root/BoardGameFramework/BoardGameManager");
			_gameManager.StartBoardGame(gameState);
		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	}
}
