using Xunit;

namespace BowlingKata
{
    public class GameTests
    {
        private static Game game;

        //Setup
        public GameTests()
        {
            game = new Game();
        }

        [Fact]
        public void Test_ScoreIs_0_WhenAllThrowsAre_0()
        {
            //Act
            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            //Assert
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void Test_ScoreIs_20_WhenAllThrowsAre_1()
        {
            //Act
            Rolls(20, 1);

            //Assert
            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void Test_ScoreIs_28_WhenOneSpareAndOne9()
        {
            // Act [5,/,9,0,.....]
            game.Roll(5);
            game.Roll(5);
            game.Roll(9);

            //Assert
            Assert.Equal(28, game.Score());
        }

        [Fact]
        public void Test_ScoreIs_28_WhenOneStrikeAndThen3And4()
        {
            //Act [X,3,4,.....]
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);

            //Assert
            Assert.Equal(24, game.Score());
        }

        [Fact]
        public void Test_ScoreIs_150_WhenAll5()
        {
            //Act [5,/,5,/,....,5]
            Rolls(21, 5);

            Assert.Equal(150, game.Score());
        }

        [Fact]
        public void Test_ScoreIs_300_ForPerfectGameWithAllStrikes()
        {
            Rolls(12, 10);

            Assert.Equal(300, game.Score());
        }

        [Fact]
        public void Test_ScoreIs_109_ForAllSparesAndA9()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(0);
                game.Roll(10);
            }
            game.Roll(9);

            Assert.Equal(109, game.Score());
        }

        /// <summary>
        /// Helper method for BowlingKata.Tests
        /// Adds a certain number of rolls with the same score to the game.
        /// </summary>
        /// <param name="rolls"></param>
        /// <param name="pins"></param>
        private static void Rolls(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
