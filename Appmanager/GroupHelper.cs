using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper (ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialog();
            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", 
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
               string item = aux.ControlTreeView(
                   GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", 
                   "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            
            CloseGroupsDialog();
            return list;
        }

        internal void RemoveGroup(int p)
        {
            OpenGroupsDialog();
            SelectGroup(p);
            DeleteGroup();
            CloseGroupsDialog();
        }

        private void DeleteGroup()
        {
            aux.ControlClick(GROUPWINTITLE, "&Delete", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait("Delete group");
            aux.ControlClick("Delete group", "&OK", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWait(GROUPWINTITLE);
        }

        private void SelectGroup(int p)
        {
            aux.ControlTreeView(
                            GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                            "Select", "#0|#" + p, "");
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53"); // click on New button
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}"); //imulition of enter press
            CloseGroupsDialog();

        }

        private void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54"); //click on close button
        }

        private void OpenGroupsDialog()
        {
            aux.ControlClick(WINTTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512"); //click on group editor button
            aux.WinWait(GROUPWINTITLE); // wait for needed window
        }
    }
}