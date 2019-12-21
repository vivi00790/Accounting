using System;
using NUnit.Framework;

namespace Accounting
{
    public class Tests
    {
        private Accounting _accounting;

        [SetUp]
        public void Setup()
        {
            _accounting = new Accounting();
            var fakeRepo = new FakeRepo();
            _accounting.Repo = fakeRepo;
        }

        [Test]
        public void test_Full_Month()
        {
            
            var startDate = DateTime.Parse("2019/12/1");
            var endDate = DateTime.Parse("2019/12/31");

            var actual = _accounting.QueryBudget(startDate, endDate);

            Assert.AreEqual(3100, actual);
        }
        
    }
}