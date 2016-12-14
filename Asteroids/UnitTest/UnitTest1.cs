using Asteroids.Model;
using Asteroids.Utils;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        AsteroidsModel model;

        [TestInitialize]
        public void Initialize()
        {
            model = new AsteroidsModel(3,3);
            model.NewGame();
        }

        [TestMethod]
        public void TurnLeft()
        {
            Assert.AreEqual(model.Player.X, 1);
            model.TurnLeft();
            Assert.AreEqual(model.Player.X, 0);
        }

        [TestMethod]
        public void TurnRight()
        {
            Assert.AreEqual(model.Player.X, 1);
            model.TurnRight();
            Assert.AreEqual(model.Player.X, 2);
        }

        [TestMethod]
        public void Pause()
        {
            Assert.AreEqual(model.Paused, false);
            model.Pause();
            Assert.AreEqual(model.Paused, true);
        }

        [TestMethod]
        public void Resume()
        {
            Assert.AreEqual(model.Paused, false);
            model.Pause();
            Assert.AreEqual(model.Paused, true);
            model.Resume();
            Assert.AreEqual(model.Paused, false);
        }
    }
}
