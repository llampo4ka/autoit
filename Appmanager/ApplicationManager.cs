using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WINTTITLE = "Free Address Book";
        private AutoItX3 aux;
        public GroupHelper groupHelper;

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"c:\Users\Demon\source\AppForTest\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WINTTITLE);
            //aux.WinActivate(WINTTITLE);
            aux.WinWaitActive(WINTTITLE);
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WINTTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public AutoItX3 Aux
        {
             get { return aux; } 
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
    }
}
