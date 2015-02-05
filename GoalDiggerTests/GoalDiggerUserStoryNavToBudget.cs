﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.BDDfy;

namespace GoalDiggerTests
{
    [TestClass]
    public class GoalDiggerUserStoryNavToBudget
    {
        //private static TestContext test_context;
        private static Window window;
        private static Application application;
        private static TextBox NavState_TextBox;
        private static Button BackNav_Button;
        private static Button Budget_Button;
        private static Button Profile_Button;
        private static Button Update_Button;
        private static Button WishList_Button;

        [ClassInitialize]
        public static void Setup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _context)
        {
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\GoalDigger\\bin\\Debug\\GoalDigger");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
            NavState_TextBox = window.Get<TextBox>("NavStateTextBox");
            BackNav_Button = window.Get<Button>("BackNavButton");
            Budget_Button = window.Get<Button>("Budget");
            Profile_Button = window.Get<Button>("Profile");
            Update_Button = window.Get<Button>("Update");
            WishList_Button = window.Get<Button>("WishList");
        }

        // As a User
        void WhenTheBudgetButtonIsClicked()
        {
            System.Threading.Thread.Sleep(500); // So we can see it
            Budget_Button.Click();
            System.Threading.Thread.Sleep(500); // So we can see it
        }

        void GivenTheMainWindowisOpen()
        {
            Assert.IsTrue(window.IsFocussed);
        }

        void ThenTheNavStateBoxShouldContainBudget()
        {
            Assert.AreEqual("Budget", NavState_TextBox.Text);
        }

        void AndThenTheBudgetButtonShouldBeDisabled()
        {
            Assert.IsFalse(Budget_Button.Enabled);
        }

        void AndThenTheProfileButtonShouldBeDisabled()
        {
            Assert.IsFalse(Profile_Button.Enabled);
        }

        void AndThenTheUpdateButtonShouldBeDisabled()
        {
            Assert.IsFalse(Update_Button.Enabled);
        }

        void AndThenTheWishListButtonShouldBeDisabled()
        {
            Assert.IsFalse(WishList_Button.Enabled);
        }

        void AndThenTheBackNavIsEnabled()
        {
            Assert.IsTrue(BackNav_Button.Enabled);
        }


        [TestMethod]
        public void StoryMainWindowNavToBudget()
        {
            this.BDDfy();
        }

        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        }
    }
}