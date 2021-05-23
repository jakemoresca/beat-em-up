using Godot;
using System;

namespace BoardGameFramework.Dices
{
	public class DiceDisplay : Node2D
	{
		private Sprite _sprite;
		private RichTextLabel _label;

		public override void _Ready()
		{
			_sprite = this.GetNode<Sprite>("./Sprite");
			_label = this.GetNode<RichTextLabel>("./Label");
		}

		public void SetDiceData(string diceArt, string diceArtName, int diceArtAngle)
		{
			var texture = ResourceLoader.Load<Texture>(diceArt);
			_sprite.Texture = texture;
			_sprite.RotationDegrees = diceArtAngle;

			_label.BbcodeText = $"[center]{diceArtName}[/center]";
		}
	}
}
