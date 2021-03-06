﻿using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages //static verince new olmaz, tek bir mesaj vereceğiz bitecek o yüzden statik
    {
        public static string ProductAdded = "Your Product Has Been Added Successfully";
        public static string ProductNameInvalid = "Your Product Name is not Valid";
        public static string MaintenanceTime = "Maintenance is Down";
        public static string ProductsListed = "Products Has Been Listed";
        public static string ProductCountOfCategoryError = "The Category Can Handle Maximum 10 Products";
        public static string ProductNameAlreadyExists = "Product Name Already Exists";
        public static string CategoryCountError = "Can't Add Products While Category Numbers Higher Than 15";
        public static string AuthorizationDenied = "Authorization Denied";
        public static string UserRegistered = "User Registered";
        public static string UserNotFound = "User Not Found";
        public static string PasswordError = "Incorrect Password";
        public static string SuccessfulLogin = "Successfull Login";
        public static string UserAlreadyExists = "User Already Exist";
        public static string AccessTokenCreated = "Access Token Created";
    }
}
