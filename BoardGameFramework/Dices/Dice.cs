using Godot;
using System;

namespace BoardGameFramework.Dices
{
    public class Dice : Node2D
    {
        [Export]
        private string DiceName;

        private Button _rollButton;
        private Sprite _sprite;
        private RichTextLabel _label;
        private bool _rolled = false;
        private float _currentTime;
        private RandomNumberGenerator _random;
        private const string HIDDEN_COLOR = "00ffffff";
        private const string VISIBLE_COLOR = "ffffffff";
        private BoardGameManager _gameManager;

        public override void _Ready()
        {
            _gameManager = (BoardGameManager)GetNode("/root/BoardGameFramework/BoardGameManager");

            this.Hide();

            _rollButton = this.GetNode<Button>("./Button");
            _sprite = this.GetNode<Sprite>("./Sprite");
            _label = this.GetNode<RichTextLabel>("./Label");

            _random = new RandomNumberGenerator();
            _random.Randomize();

            _rollButton.Connect("pressed", this, "_on_Button_pressed");
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

            if(diceState.CurrentDice != Name || !diceState.DicesData.TryGetValue(Name, out var diceData))
                return;

            var diceManager = _gameManager.GetDiceManager();

            if (diceState.CurrentDicePhase == DicePhase.Rolling)
            {
                _currentTime += (delta * 1000);

                var diceArts = diceData.DiceArts;
                var diceArtAngle = diceData.DiceArtAngles;
                var diceNames = diceData.DiceNames;

                var selectedIndex = _random.Randi() % diceArts.Length;

                var texture = ResourceLoader.Load<Texture>(diceArts[selectedIndex]);
                _sprite.Texture = texture;
                _sprite.RotationDegrees = diceArtAngle[selectedIndex];

                _label.BbcodeText = $"[center]{diceNames[selectedIndex]}[/center]";

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
                }
            }
        }
    }
}