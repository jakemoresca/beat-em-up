using Godot;
using System;

namespace BoardGameFramework.Dices
{
	public class Dice : Node2D
	{
		private Button _rollButton;
		private Node2D _diceDisplays;
		private float _currentTime;
		private RandomNumberGenerator _random;
		private const string HIDDEN_COLOR = "00ffffff";
		private const string VISIBLE_COLOR = "ffffffff";
		private BoardGameManager _gameManager;
		private string _listenerName;
		DiceState _currentDiceState;
		private bool _isInitialized = false;

		public override void _Ready()
		{
			_gameManager = (BoardGameManager)GetNode("/root/FrameworkBoardGameManager");

			this.Hide();

			_random = new RandomNumberGenerator();
			_random.Randomize();

			_diceDisplays = GetNode<Node2D>("./Displays");

			_rollButton = GetNode<Button>("./Button");
			_rollButton.Connect("pressed", this, "_on_Button_pressed");

			_listenerName = $"DICE_{this.GetInstanceId()}";
		}

		private void _on_Button_pressed()
		{
			var diceManager = _gameManager.GetDiceManager();
			diceManager.RollDice();
		}

		public override void _Process(float delta)
		{
			var gameState = _gameManager.GetState();
			var diceState = gameState.DiceState;

			if (diceState.CurrentDicePhase == DicePhase.Hidden)
			{
				this.Hide();
				return;
			}

			if (!diceState.DicesData.TryGetValue(diceState.CurrentDice, out var diceData))
				return;

			if (!_isInitialized)
			{
				var instanceCount = diceData.DiceInstances;

				foreach (DiceDisplay diceDisplay in _diceDisplays.GetChildren())
				{
					diceDisplay.Free();
				}

				var widthPerCell = 84;

				for (var x = 0; x < instanceCount; x++)
				{
					var diceDisplayScene = ResourceLoader.Load<PackedScene>(diceData.DicePath);

					if (diceDisplayScene != null)
					{
						var diceDisplayInstance = (DiceDisplay)diceDisplayScene.Instance();
						_diceDisplays.AddChild(diceDisplayInstance);

						diceDisplayInstance.Position = new Vector2(x * widthPerCell, 0);
					}
				}

				_diceDisplays.Position = new Vector2(-84, 0);
				_isInitialized = true;

				this.Show();
			}

			var diceManager = _gameManager.GetDiceManager();

			if (diceState.CurrentDicePhase == DicePhase.Rolling)
			{
				_currentTime += (delta * 1000);

				var diceArts = diceData.DiceArts;
				var diceArtAngle = diceData.DiceArtAngles;
				var diceNames = diceData.DiceNames;

				foreach (DiceDisplay diceDisplay in _diceDisplays.GetChildren())
				{
					var selectedIndex = _random.Randi() % diceArts.Length;

					diceDisplay.SetDiceData(diceArts[selectedIndex], diceNames[selectedIndex], diceArtAngle[selectedIndex]);
				}

				if (_currentTime >= 1000)
				{
					_currentTime = 0;

					diceManager.SetRandomValue(); //will trigger hiding
				}
			}
			else if (diceState.CurrentDicePhase == DicePhase.Hiding)
			{
				_currentTime += (delta * 0.004f);

				var newColor = this.Modulate.LinearInterpolate(new Color(HIDDEN_COLOR), _currentTime);
				this.Modulate = newColor;

				if (this.Modulate.ToHtml() == HIDDEN_COLOR)
				{
					diceManager.HideDice();
					_isInitialized = false;
				}
			}
		}
	}
}
