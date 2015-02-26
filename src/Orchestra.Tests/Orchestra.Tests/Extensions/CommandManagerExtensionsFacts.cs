﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandManagerExtensionsFacts.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Tests
{
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Windows.Input;
    using NUnit.Framework;
    using CommandManager = Catel.MVVM.CommandManager;
    using InputGesture = Catel.Windows.Input.InputGesture;

    [TestFixture]
    public class CommandManagerExtensionsFacts
    {
        [TestCase(Key.A, ModifierKeys.Control, true)]
        [TestCase(Key.A, ModifierKeys.Shift, false)]
        [TestCase(Key.A, ModifierKeys.None, false)]
        [TestCase(Key.B, ModifierKeys.Control, false)]
        public void TheFindCommandsByGestureMethod(Key key, ModifierKeys modifierKeys, bool expectedToBeAvailable)
        {
            var commandManager = new CommandManager();

            commandManager.CreateCommand("CtrlA", new InputGesture(Key.A, ModifierKeys.Control));

            var inputGesture = new InputGesture(key, modifierKeys);
            var existingCommands = commandManager.FindCommandsByGesture(inputGesture);

            Assert.AreEqual(expectedToBeAvailable, existingCommands.Any());
        }
    }
}