using NUnit.Framework;
using BowlingGameKata;

namespace BowlingGame.Tests
{
    public class Tests
    {
        Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [TearDown]
        public void TearDown()
        {
            game = null;
        }

        [Test]
        public void TestGame()
        {

        }

        [Test]
        public void TestRoll()
        {
            game.Roll(0);
        }

        [Test]
        public void TestScore()
        {
            game.Roll(3);
            game.Roll(4);
            Assert.AreEqual(7, game.Score());
        }

        [Test]
        public void TestSpare()
        {
            game.Roll(6);
            game.Roll(4);//bowler has knocked down all pins in 2 tries = Spare, score = 10
            game.Roll(6); //spare means update previous try with value from this roll = 15 and then add this rolls value to score = 22
            Assert.AreEqual(22, game.Score());
        }

        [Test]
        public void TestStrike()
        {
            game.Roll(10);//strike 10 + next 2 rolls (20)
            game.Roll(4); //24
            game.Roll(6);  //30
            Assert.AreEqual(30, game.Score());
        }
    }
}