using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CSharp
{
    public class Connection
    {
        private string _filename;

        private static Connection _conn;

        private Connection()
        {
            _filename = "appsettings.json";
        }

        public static Connection Instance
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new Connection();
                }
                return _conn;
            }
            set
            {
                _conn = value;
            }
        }

        public string GetConnectionString()
        {
            var builder =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(_filename,
                                 optional: true,
                                 reloadOnChange: true);
            return builder
                .Build()
                .GetSection("ConnectionStrings")
                .GetSection("DefaultConnection")
                .Value;
        }
    }
}
