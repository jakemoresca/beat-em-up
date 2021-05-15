using System;
using System.Collections.Generic;

namespace BoardGameFramework.Actions
{
    public class ActionManager
    {
        private Dictionary<string, BaseAction> _actions;
        private readonly Func<IGameState, IGameState> _updateStateCallback;

        public ActionManager(Func<IGameState, IGameState> updateStateCallback)
        {
            _actions = new Dictionary<string, BaseAction>();
            _updateStateCallback = updateStateCallback;
        }

        public void RegisterAction(BaseAction action)
        {
            _actions.Add(action.Name, action);
        }

        public void InvokeAction(string actionName, SimpleValue[] args)
        {
            var action = _actions[actionName];
            
            _updateStateCallback(action.InvokeAction(args));
        }
    }
}