using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinerMax3000.Business;

namespace DinerMax3000Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Want to load from DB
            //FoodMenu summerMenu = new FoodMenu();
            //summerMenu.Name = "Summer Menu";
            //summerMenu.AddMenuItem("Salmon","Fresh Norwegian Salmon with Sandefjord butter.",25.50);
            //summerMenu.AddMenuItem("Taco", "All Norwegians eat Tacos on Friday", 10.00);
            //summerMenu.HospitalDirections = "Right around corner. Ask for Dr. Strange.";

            //DrinkMenu outsideDrinks = new DrinkMenu();
            //outsideDrinks.Disclaimer = "Do not drink and code.";
            //outsideDrinks.AddMenuItem("Virgin Cuba Libre", "A classic!", 10);
            //outsideDrinks.AddMenuItem("Screwdriver", "Leaves you hammered!", 15);

            List<Menu> menusFromDatabase = Menu.GetAllMenus();

            //Add another item to the first menu
            Menu firstMenu = menusFromDatabase[0];
            firstMenu.SaveNewMenuItem("Grits", "A southern classic", 5.0);

            //Reload menu
            menusFromDatabase = Menu.GetAllMenus();

            Order hungryGuestOrder = new Order();
            // Want to use DB
            //for (int x = 0; x <= summerMenu.items.Count - 1; x++)
            //{
            //    MenuItem currentItem = summerMenu.items[x];
            //    hungryGuestOrder.items.Add(currentItem);
            //}

            foreach (Menu currentMenu in menusFromDatabase)
            {
                foreach (MenuItem currentItem in currentMenu.items)
                {
                    hungryGuestOrder.items.Add(currentItem);
                }
            }
            Console.WriteLine("The total is: " + hungryGuestOrder.Total);

            // Used prior to DB
            //try
            //{

            //    outsideDrinks.AddMenuItem("Himkok", "9 of 10 people recommend avoiding this drink", 0);
            //}
            //catch (Exception thrownException)
            //{
            //    Console.WriteLine(thrownException.Message);
            //}
            Console.ReadKey();

        }
    }
}
