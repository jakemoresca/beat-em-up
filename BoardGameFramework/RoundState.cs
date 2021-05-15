namespace BoardGameFramework
{
    public class RoundState
    {
        public RoundState(int roundnumber, int currentPlayerNumberTurn)
        {
            RoundNumber = roundnumber;
            CurrentPlayerNumberTurn = currentPlayerNumberTurn;
        }

        int RoundNumber { get; }
        int CurrentPlayerNumberTurn { get; }
    }
}