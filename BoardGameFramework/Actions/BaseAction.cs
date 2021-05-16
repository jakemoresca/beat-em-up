using System;

namespace BoardGameFramework.Actions
{
    public class BaseAction
    {
        private readonly BoardGameManager _boardGameManager;

        public BaseAction(string name, BoardGameManager boardGameManager, Func<SimpleValue[], Func<IGameState>, Func<GameStateBuilder>, IGameState> action)
        {
            Name = name;
            Action = action;
            _boardGameManager = boardGameManager;
        }

        public string Name { get; }

        public Func<SimpleValue[], Func<IGameState>, Func<GameStateBuilder>, IGameState> Action { get; }

        public IGameState InvokeAction(SimpleValue[] args)
        {
            return Action.Invoke(args, _boardGameManager.GetState, _boardGameManager.GetGameStateBuilder);
        }
    }
}