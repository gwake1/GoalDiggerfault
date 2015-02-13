﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using GoalDigger;
using GoalDigger.Model;
using GoalDigger.Repository;

namespace GoalDigger
{
    public class TestHelper
    {
        private static TestContext test_context;
        protected static Window window;
        private static Application application;
        private static WishRepository repo = new WishRepository();
        private static WishContext context;
        private static String applicationPath;

        public static void SetupClass(TestContext _context)
        {
            var applicationDir = _context.DeploymentDirectory;
            applicationPath = Path.Combine(applicationDir, "..\\..\\..\\GoalDigger\\bin\\Debug\\GoalDigger");
        }

        public static void TestPrep()
        {
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
            context = repo.Context();
        }


        public void AndIShouldSeeAnErrorMessage(string p)
        {
            throw new NotImplementedException();
        }

        public void ThenIShouldSeeXWishes(int expected)
        {
            Assert.IsNotNull(window);
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("CountdownList").AndIndex(0);
            ListBox list_box = (ListBox)window.Get(searchCriteria);
            Assert.AreEqual(expected, list_box.Items.Count);
        }

        public void AndIShouldSeeXWishes(int x)
        {
            ThenIShouldSeeXWishes(x);
        }

        public void AndTheButtonShouldBeEnabled(string buttonContent)
        {
            Button button = window.Get<Button>(SearchCriteria.ByText(buttonContent));
            Assert.IsTrue(button.Enabled);
        }

        public void AndTheButtonShouldBeDisabled(string buttonContent)
        {
            Button button = window.Get<Button>(SearchCriteria.ByText(buttonContent));
            Assert.IsFalse(button.Enabled);
        }

        public void ThenIShouldNotSeeTheWishForm()
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("AddWish"));
            Assert.IsFalse(button.Visible);
        }

        public void ThenIShouldNotSeeTheWishCompForm()
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("AddWishComp"));
            Assert.IsFalse(button.Visible);
        }

        public void AndIClick(string buttonContent)
        {
            WhenIClick(buttonContent);
        }

        public void AndIChooseTheEventDate(DateTime newDate)
        {
            DateTimePicker picker = window.Get<DateTimePicker>(SearchCriteria.ByAutomationId("EventDate"));
            picker.SetValue(newDate);
        }

        public void WhenIFillInWishTitleWith(string value)
        {
            var textBox = window.Get<TextBox>("WishTitle");
            textBox.SetValue(value);
        }

        public void ThenIShouldSeeTheWishForm()
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("AddWish"));
            Assert.IsTrue(button.Visible);
        }

        public void WhenIClick(string buttonContent)
        {
            Button button = window.Get<Button>(SearchCriteria.ByText(buttonContent));
            button.Click();
        }

        public void GivenThereAreNoEvents()
        {
            Assert.AreEqual(0, repo.GetCount());
        }

        public static void GivenTheseEvents(params Wish[] wishes)
        {
            foreach (Wish evnt in wishes)
            {
                // Add event to Events here.
                repo.Add(evnt);
            }

            //context.SaveChanges();
            Assert.AreEqual(wishes.Length, repo.GetCount());
        }

        public static void CleanThisUp()
        {
            window.Close();
            application.Close();
            repo.Clear();
        }
    }
}
