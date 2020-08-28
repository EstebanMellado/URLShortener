﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Api.Repositories;

namespace URLShortener.Api.Services
{
    public class LogService : ILogService
    {
        private readonly IURLRepository _urlRepository;

        public LogService(IURLRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public void LogInfo(string text)
        {
            throw new NotImplementedException();
        }
    }
}