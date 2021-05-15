using System;

namespace BoardGameFramework.Actions
{
    public class BaseAction
    {
        public BaseAction(string name, Func<SimpleValue[], IGameState> action)
        {
            Name = name;
            Action = action;
        }

        public string Name { get; }

        public Func<SimpleValue[], IGameState> Action { get; }

        public IGameState InvokeAction(SimpleValue[] args)
        {
            return Action.Invoke(args);
        }
    }
}