using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace BARAN
{
    public static class AddUser
    {
        // SQL Server connection string
        private static readonly string ConnStr = @"Server=localhost\SQL;Database=LoginDB;Trusted_Connection=True;";

        // Yeni kullanıcı ekleme
        public static void CreateUser(string username, string password, int iterations = 10000)
        {
            byte[] salt = GenerateSalt(16);
            byte[] hash = HashPassword(password, salt, iterations, 32);

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO dbo.Users (Username, PasswordHash, Salt, Iterations) VALUES (@u, @h, @s, @it)";
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 100).Value = username;
                cmd.Parameters.Add("@h", SqlDbType.VarBinary, 64).Value = hash;
                cmd.Parameters.Add("@s", SqlDbType.VarBinary, 64).Value = salt;
                cmd.Parameters.Add("@it", SqlDbType.Int).Value = iterations;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        private static byte[] HashPassword(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return pbkdf2.GetBytes(outputBytes);
            }
        }

        private static byte[] GenerateSalt(int size = 16)
        {
            var s = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(s);
            }
            return s;
        }
    }
}
