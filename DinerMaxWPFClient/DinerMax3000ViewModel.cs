using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinerMax3000.Business;

namespace DinerMaxWPFClient
{
    public class DinerMax3000ViewModel
    {
        public List<Menu> AllMenus
        {
            get
            {
                return Menu.GetAllMenus();
            }
        }
        private Menu _selectedMenu = new Menu();
        public Menu SelectedMenu
        {
            get
            {
                return _selectedMenu;
            }
            set
            {
                _selectedMenu = value;
            }

        }
        private MenuItem _newMenuItem = new MenuItem();
        public MenuItem NewMenuItem
        {
            get
            {
                return _newMenuItem;
            }
            set
            {
                _newMenuItem = value;
            }
        }
    }
}
