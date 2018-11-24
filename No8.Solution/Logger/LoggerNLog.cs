//-----------------------------------------------------------------------
// <copyright file="LoggerNLog.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;
using NLog;

namespace No8.Solution.Logger
{
    /// <summary>
    /// NLog logger class
    /// </summary>
    public class LoggerNLog : ILog
    {
        private static NLog.Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerNLog"/> class
        /// </summary>
        /// <param name="name">
        /// Logger name
        /// </param>
        public LoggerNLog(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            logger = NLog.LogManager.GetLogger(name);
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="message">
        /// Some information
        /// </param>
        public void Info(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Log errors
        /// </summary>
        /// <param name="message">
        /// Error information
        /// </param>
        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}
