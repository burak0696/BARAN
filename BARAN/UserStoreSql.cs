using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace LoginDemoFramework
{
    public static class UserStoreSql
    {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["MyDb"]?.ConnectionString;

        public static bool ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(ConnStr))
                throw new InvalidOperationException("Connection string 'MyDb' bulunamadı. App.config kontrol et.");

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT PasswordHash, Salt, Iterations FROM dbo.Users WHERE Username = @u";
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 100).Value = username ?? string.Empty;

                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (!reader.Read())
                        return false; // kullanıcı yok

                    if (reader.IsDBNull(0) || reader.IsDBNull(1))
                        return false; // beklenen veri yok

                    byte[] storedHash = (byte[])reader["PasswordHash"];
                    byte[] salt = (byte[])reader["Salt"];
                    int iterations = reader.IsDBNull(2) ? 10000 : Convert.ToInt32(reader["Iterations"]);

                    if (storedHash == null || storedHash.Length == 0 || salt == null || salt.Length == 0)
                        return false;

                    byte[] actualHash = HashPassword(password, salt, iterations, storedHash.Length);

                    return FixedTimeEquals(storedHash, actualHash);
                }
            }
        }

        public static void AddUser(string username, string plainPassword, int iterations = 10000)
        {
            if (string.IsNullOrWhiteSpace(ConnStr))
                throw new InvalidOperationException("Connection string 'MyDb' bulunamadı. App.config kontrol et.");

            byte[] salt = GenerateSalt(16);
            byte[] hash = HashPassword(plainPassword, salt, iterations, 32); // 32 byte hash

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

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}
