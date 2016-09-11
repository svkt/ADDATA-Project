using System;
using System.Collections.Generic;
using System.Linq;

namespace StockInventory.Classes
{
    public static class UserRepository
    {
        public static StockInventoryDataContext db;

        public static User Login(User user)
        {
            try
            {
                db = new StockInventoryDataContext();
                return db.Users.SingleOrDefault(p => string.Equals(p.Username, user.Username, StringComparison.OrdinalIgnoreCase) && string.Equals(p.Password, user.Password, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static User ForgotPassword(User user)
        {
            try
            {
                db = new StockInventoryDataContext();
                return db.Users.SingleOrDefault(p => string.Equals(p.Username, user.Username, StringComparison.OrdinalIgnoreCase) && p.SecretQuestion == user.SecretQuestion && string.Equals(p.SecretAnswer, user.SecretAnswer, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static User GetOne(int id)
        {
            try
            {
                db = new StockInventoryDataContext();
                return db.Users.SingleOrDefault(p => p.UserID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<User> GetList()
        {
            try
            {
                db = new StockInventoryDataContext();
                return db.Users.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<User> Search(string searchText)
        {
            try
            {
                db = new StockInventoryDataContext();
                return db.Users.Where(p => p.Username.Contains(searchText)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void Insert(User user)
        {
            try
            {
                db = new StockInventoryDataContext();
                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception ex) { }
        }

        public static void Update(User user)
        {
            try
            {
                db = new StockInventoryDataContext();
                var existingUser = db.Users.SingleOrDefault(p => p.UserID == user.UserID);
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.SecretQuestion = user.SecretQuestion;
                existingUser.SecretAnswer = user.SecretAnswer;
                existingUser.IsActive = user.IsActive;
                existingUser.IsAdmin = user.IsAdmin;
                db.SubmitChanges();
            }
            catch (Exception ex) { }
        }

        public static void Delete(User user)
        {
            try
            {
                db = new StockInventoryDataContext();
                db.Users.DeleteOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception ex) { }
        }
    }
}
