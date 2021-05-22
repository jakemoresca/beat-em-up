using Godot;
using System;

namespace BoardGameFramework.Boards
{
    public class BoardUnit : Area2D
    {
        // Declare member variables here. Examples:
        private Board _map;
        private string _direction;
        private GridPosition _position;
        private int _playerNumber;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _map = this.GetNode<Board>("../../MainMap");
            _direction = "up";

            _position = new GridPosition { Column = -1, Row = -1 };

            this.Connect("input_event", this, "_on_Player_input_event");
        }

        public void SetGridPosition(int column, int row, string direction = "up")
        {
            _direction = direction;
            _position.Column = column;
            _position.Row = row;

            var tileSize = _map.GetTileSize();
            var initCoordinates = _map.GetInitCoordinates();

            var animatedSprite = this.GetNode<AnimatedSprite>("./AnimatedSprite");
            animatedSprite.Animation = _direction;

            var position = BoardPositionHelper.GetTargetPosition(_map.Tilemap, _position, (int)tileSize, initCoordinates);
            this.Position = new Vector2(position.x, position.y - 28);
        }

        public GridPosition GetGridPosition()
        {
            return _position;
        }

        public string GetDirection()
        {
            return _direction;
        }

        public void SpawnTo(int column, int row)
        {
            var tileSize = _map.GetTileSize();
            var initCoordinates = _map.GetInitCoordinates();

            _position.Row = row;
            _position.Column = column;

            var position = BoardPositionHelper.GetTargetPosition(_map.Tilemap, _position, (int)tileSize, initCoordinates);
            this.Position = new Vector2(position.x, position.y - 28);

            this.Show();
        }

        public void FaceDirection(string direction)
        {
            var animatedSprite = this.GetNode<AnimatedSprite>("./AnimatedSprite");
            animatedSprite.Animation = direction;

            _direction = direction;
        }

        public bool HasPosition()
        {
            return _position.Column > -1 && _position.Row > -1;
        }

        public AnimatedSprite GetAnimatedSprite()
        {
            return this.GetNode<AnimatedSprite>("./AnimatedSprite");
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _playerNumber = playerNumber;
        }

        public int GetPlayerNumber()
        {
            return _playerNumber;
        }

        public void KillUnit()
        {
            _map.RemoveChild(this);
            this.Free();
        }
    }
}
