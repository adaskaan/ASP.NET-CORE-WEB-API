using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string EntryAdded = "Entry Added";
        public static string EntryDeleted = "Entry Deleted";
        public static string EntryUpdated = "Entry Updated";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccesfulLogin = "Giriş Başarılı";
        public static string UserExists = "Kullanıcı Mevcut";
        public static string UserRegistered = "Kayıt Başarılı";
        public static string AccessTokenCreated="Access Token Başarıyla Oluşturuldu";
        public static string CategoryCreated = "Kategory Başarıyla Eklendi";
    }
}