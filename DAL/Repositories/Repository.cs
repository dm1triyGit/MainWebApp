using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DAL.Repositories
{
    public class Repository : IRepository
    {
        private readonly ILogger<Repository> logger;
        private  string dataBasePath;

        public Repository(ILogger<Repository> logger)
        {
            this.logger = logger;            
        }

        public T GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save<T>(T model)
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T model)
        {
            throw new NotImplementedException();
        }
    }
}
