namespace BowlingKata
{
    /// <summary>
    /// The main Bowling game class.
    /// </summary>
    public class Game
    {
        private int _score;
        private int _rollIndex;
        private int[] _rolls;

        public Game()
        {
            _rolls = new int[21];
        }

        /// <summary>
        /// Add a roll with a specific number of pins to the game.
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            _rolls[_rollIndex] = pins;
            _rollIndex++;
        }

        /// <summary>
        /// Calculates the score of the game.
        /// </summary>
        /// <returns>score</returns>
        public int Score()
        {
            int frame = 1;

            for (int frameIndex = 0; frameIndex < _rolls.Length - 1; frameIndex++)
            {
                if (_rolls[frameIndex] == 10)                                       // Strike
                {
                    _score += StrikeScore(frameIndex);
                }
                else if (_rolls[frameIndex] + _rolls[frameIndex + 1] == 10)         //Spare
                {
                    _score += SpareScore(frameIndex++);
                }
                else
                {
                    _score += OpenFrameScore(frameIndex++);                         // Open frame
                }

                if (frame == 10)                                                    // Last frame?
                {
                    break;
                }

                frame++;
            }
            return _score;
        }

        private int OpenFrameScore(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int SpareScore(int frameIndex)
        {
            return 10 + _rolls[frameIndex + 2];
        }

        private int StrikeScore(int frameIndex)
        {
            return 10 + _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }
    }
}
