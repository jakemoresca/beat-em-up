using BoardGameFramework.Actions;

namespace BoardGameFramework.Dices
{
    public class DiceManager
    {
        private readonly ActionManager _actionManager;

        public DiceManager(ActionManager actionManager, BoardGameManager boardGameManager)
        {
            _actionManager = actionManager;

            RegisterDiceActions(boardGameManager);
        }

        private void RegisterDiceActions(BoardGameManager boardGameManager)
        {
            var diceActions = DiceActions.GetDiceActions(boardGameManager);

            foreach (var diceAction in diceActions)
            {
                _actionManager.RegisterAction(diceAction);
            }
        }

        public void AddDice(string name, string dicePath, string[] diceNames, int[] diceArtAngles, string[] diceArts)
        {
            var args = new[] { new SimpleValue(name), new SimpleValue(dicePath), new SimpleValue(diceNames), 
                new SimpleValue(diceArtAngles), new SimpleValue(diceArts) };

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