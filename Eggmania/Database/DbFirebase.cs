using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Eggmania.Models;

namespace Eggmania.Database
{
    public class DbFirebase
    {
        FirebaseClient client;
        public DbFirebase()
        {
            client = new FirebaseClient("https://eggmania-3a668.firebaseio.com/");
        }

        public async Task<List<MainMenuModel>> getCategories()
        {
            var list = (await client
                        .Child("Category")
                        .OnceAsync<MainMenuModel>())
                        .Select(item =>
                                new MainMenuModel
                                {
                                    DisplayName = item.Object.DisplayName,
                                    ImageName = item.Object.ImageName,
                                    Order = item.Object.Order,
                                    Key = item.Key
                                }).OrderBy(d => d.Order).ToList();

            return list;
        }


        public async Task<List<AddOn>> getAddOns()
        {
            var list = (await client
                        .Child("AddOn")
                        .OnceAsync<AddOn>())
                        .Select(item =>
                                new AddOn
                                {
                                    InternalName = item.Object.InternalName,
                                    Title = item.Object.Title,
                                    Description = item.Object.Description,
                                    AddOnItems = item.Object.AddOnItems,
                                    IsMandatory = item.Object.IsMandatory,
                                    Key = item.Key
                                }).ToList();

            return list;
        }




        public async Task<List<MenuItemModel>> getMenuItems()
        {
            var list = (await client
                        .Child("MenuItem")
                        .OnceAsync<MenuItemModel>())
                        .Select(item =>
                                new MenuItemModel
                                {
                                    Name = item.Object.Name,
                                    Price = item.Object.Price,
                                    IsSpicy = item.Object.IsSpicy,
                                    IsVeg = item.Object.IsVeg,
                                    IsMostPopular = item.Object.IsMostPopular,
                                    Order = item.Object.Order,
                                    CategoryID = item.Object.CategoryID,
                                    AddOnItems = item.Object.AddOnItems,
                                    AddOnItemList = generateAddOnItemList(item.Object.AddOnItems),
                                    Key = item.Key
                                }).OrderBy(d => d.Order).ToList();

            return list;
        }

        private List<AddOn> generateAddOnItemList(List<string> addOnItems)
        {
            List<AddOn> addOnList = new List<AddOn>();
            foreach(var item in addOnItems){
                addOnList.Add(App.addOnList.Where(d => d.Key == item).FirstOrDefault());
            }
            return addOnList;
        }


        public async Task saveCategories()
        {
            List<MainMenuModel> mainMenuItems = new List<MainMenuModel>();
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Egg Samplers", ImageName = "EggSamplers.png", Order = 1 });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Egg Xotica", ImageName = "EggXotica.png", Order = 2 });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Butterly Delicious", ImageName = "ButterlyDelicious.png", Order = 3 });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Bombay Grill Sandwich", ImageName = "Grilled.png", Order = 4 });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Paneer Da Chaska", ImageName = "ButterlyDelicious.png", Order = 5 });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Rice", ImageName = "Rice.png", Order = 6 });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Beverages", ImageName = "Beverages.png", Order = 7 });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Eggxtra", ImageName = "Extra.png", Order = 8 });

            foreach (var itm in mainMenuItems)
            {
                await (client.Child("Category").PostAsync<MainMenuModel>(itm));
            }
        }


        public async Task saveAddOnItems()
        {
            List<AddOnItem> breadItems = new List<AddOnItem>() { new AddOnItem { DisplayName = "Chapati - 1 piece:", Price = 0.0M }, new AddOnItem { DisplayName = "Bread - 3 piece", Price = 0.0M } };
            AddOn breadAddOn = new AddOn()
            {
                InternalName = "BreadAddOn",
                Title = "Choose your Bread (Required)",
                Description = "Select One",
                AddOnItems = breadItems
            };

            await (client.Child("AddOn").PostAsync<AddOn>(breadAddOn));

            List<AddOnItem> cookingPrefItems = new List<AddOnItem>() { new AddOnItem { DisplayName = "Oil:", Price = 0.0M }, new AddOnItem { DisplayName = "Butter :", Price = 0.99M }, new AddOnItem { DisplayName = "Olive Oil:", Price = 1.99M } };
            AddOn cookingPrefAddOn = new AddOn()
            {
                InternalName = "CookingPrefAddOn",
                Title = "Your Cooking Preference",
                Description = "All items cooked in Oil if no option selected",
                AddOnItems = cookingPrefItems
            };

            await (client.Child("AddOn").PostAsync<AddOn>(cookingPrefAddOn));

            List<AddOnItem> extraCheeseItems = new List<AddOnItem>() { new AddOnItem { DisplayName = "Extra Cheese:", Price = 1.99M } };
            AddOn extraCheeseAddOn = new AddOn()
            {
                InternalName = "ExtraCheeseAddOn",
                Title = "Extra Cheese",
                Description = "Please select",
                AddOnItems = extraCheeseItems
            };

            await (client.Child("AddOn").PostAsync<AddOn>(extraCheeseAddOn));

            List<AddOnItem> sodaItems = new List<AddOnItem>() { new AddOnItem { DisplayName = "Coke:", Price = 0.00M }, new AddOnItem { DisplayName = "Diet Coke:", Price = 0.00M }, new AddOnItem { DisplayName = "Sprite:", Price = 0.00M } };
            AddOn sodaAddOn = new AddOn()
            {
                InternalName = "SodaAddOn",
                Title = "Your Choice (Required)",
                Description = "Please Select",
                AddOnItems = sodaItems
            };

            await (client.Child("AddOn").PostAsync<AddOn>(sodaAddOn));

            List<AddOnItem> thumsUpLimcaItems = new List<AddOnItem>() { new AddOnItem { DisplayName = "Thums Up:", Price = 0.00M }, new AddOnItem { DisplayName = "Limca:", Price = 0.00M } };
            AddOn thumsUpLimca = new AddOn()
            {
                InternalName = "ThumsUpLimcaAddOn",
                Title = "Thums Up or Limca (Required)",
                Description = "Please Select",
                AddOnItems = sodaItems
            };

            await (client.Child("AddOn").PostAsync<AddOn>(thumsUpLimca));
        }


        public async Task saveMenuItemEggSamplers()
        {
            //Egg Samplers
            string categoryID = (await client.Child("Category").OnceAsync<MainMenuModel>()).Where(d => d.Object.DisplayName == "Egg Samplers").FirstOrDefault().Key;
            string breadAddOn = (await client.Child("AddOn").OnceAsync<AddOn>()).Where(d => d.Object.InternalName == "BreadAddOn").FirstOrDefault().Key;
            string cookingPrefAddOn = (await client.Child("AddOn").OnceAsync<AddOn>()).Where(d => d.Object.InternalName == "CookingPrefAddOn").FirstOrDefault().Key;
            string extraCheeseAddOn = (await client.Child("AddOn").OnceAsync<AddOn>()).Where(d => d.Object.InternalName == "ExtraCheeseAddOn").FirstOrDefault().Key;
            string sodaAddOn = (await client.Child("AddOn").OnceAsync<AddOn>()).Where(d => d.Object.InternalName == "SodaAddOn").FirstOrDefault().Key;
            string thumsUpLimcaAddOn = (await client.Child("AddOn").OnceAsync<AddOn>()).Where(d => d.Object.InternalName == "ThumsUpLimcaAddOn").FirstOrDefault().Key;

            var boiledEggs = new MenuItemModel() { Order = 1, CategoryID = categoryID, Name = "Boiled eggs", Price = 1.99, IsVeg = false, IsSpicy = false, IsMostPopular = false };
            await (client.Child("MenuItem").PostAsync<MenuItemModel>(boiledEggs));

            var frenchToast = new MenuItemModel() { Order = 2, CategoryID = categoryID, Name = "French Toast", Price = 3.99, IsVeg = false, IsSpicy = false, IsMostPopular = false };
            frenchToast.AddOnItems.Add(breadAddOn);
            await (client.Child("MenuItem").PostAsync<MenuItemModel>(frenchToast));

            var boilFry = new MenuItemModel() { Order = 3, CategoryID = categoryID, Name = "Boil Fry", Price = 5.49, IsVeg = false, IsSpicy = true, IsMostPopular = true };
            boilFry.AddOnItems.Add(cookingPrefAddOn);
            await (client.Child("MenuItem").PostAsync<MenuItemModel>(boilFry));

            var masalOmelet = new MenuItemModel() { Order = 4, CategoryID = categoryID, Name = "Masala Omelet", Price = 3.99, IsVeg = false, IsSpicy = false, IsMostPopular = false };
            masalOmelet.AddOnItems.Add(cookingPrefAddOn);
            await (client.Child("MenuItem").PostAsync<MenuItemModel>(masalOmelet));

            var eggKatori = new MenuItemModel() { Order = 5, CategoryID = categoryID, Name = "Egg Katori", Price = 6.49, IsVeg = false, IsSpicy = false, IsMostPopular = true };
            eggKatori.AddOnItems.Add(cookingPrefAddOn);
            await (client.Child("MenuItem").PostAsync<MenuItemModel>(eggKatori));

            var jettRolls = new MenuItemModel() { Order = 6, CategoryID = categoryID, Name = "Jetty Rolls", Price = 6.49, IsVeg = false, IsSpicy = false, IsMostPopular = false };
            jettRolls.AddOnItems.Add(cookingPrefAddOn);
            await (client.Child("MenuItem").PostAsync<MenuItemModel>(jettRolls));

            var masalHalfFry = new MenuItemModel() { Order = 7, CategoryID = categoryID, Name = "Masala Half Fry", Price = 5.99, IsVeg = false, IsSpicy = true, IsMostPopular = false };
            masalHalfFry.AddOnItems.Add(cookingPrefAddOn);
            await (client.Child("MenuItem").PostAsync<MenuItemModel>(masalHalfFry));
        }

    }
}
