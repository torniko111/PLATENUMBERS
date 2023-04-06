﻿using Microsoft.Extensions.Logging;
using Platenumbers.Application.Contracts.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platenumbers.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}
