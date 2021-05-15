using BoardGameFramework.Actions;

namespace BoardGameFramework.Dices
{
    public class DiceManager
    {
        private readonly ActionManager _actionManager;

        public DiceManager(ActionManager actionManager)
        {
            _actionManager = actionManager;
        }

        public void AddDice(string name, string dicePath)
        {
            var args = new[] { new SimpleValue(name), new SimpleValue(dicePath) };

            _actionManager.InvokeAction(BaseActionNames.AddDice, args);
        }

        public void ShowDice(string name)
        {
            var args = new[] { new SimpleValue(name) };

            _actionManager.InvokeAction(BaseActionNames.ShowDice, args);
        }

        public void RollDice()
        {
            var args = new SimpleValue[] { };

            _actionManager.InvokeAction(BaseActionNames.RollDice, args);
        }

        public void SetRandomValue()
        {
            var args = new SimpleValue[] { };

            _actionManager.InvokeAction(BaseActionNames.SetRandomValue, args);
        }

        public void HideDice()
        {
            var args = new SimpleValue[] { };

            _actionManager.InvokeAction(BaseActionNames.RollDice, args);
        }
    }
}