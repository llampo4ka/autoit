using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.CheckItemsExists();

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData groupToDel = oldGroups[0];

            app.Groups.RemoveGroup(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            /*foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Name, groupToDel.Name);
            };*/
        }
    }
}
