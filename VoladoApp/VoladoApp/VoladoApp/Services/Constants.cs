using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VoladoApp.Services
{
    public static class Constants
    {
        public const string DatabaseFileName = "SQLiteDatabase.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // abrir la database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // crear la database si no existe
            SQLite.SQLiteOpenFlags.Create |
            // activa el acceso a multi-treaded database
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }
    }
}
