﻿namespace Indt.Sistema.Seguros.Infra.DataBase.EntityFramework
{
    public class DbOptions
    {
        public string ConnectionString { get; init; }

        public string Shema { get; init; }

        public DbOptions(string connectionString, string shema)
        {
            ConnectionString = string.IsNullOrWhiteSpace(connectionString) ?
                                throw new ArgumentException(nameof(connectionString)) :
                                connectionString;
            Shema = shema;
        }
    }
}
