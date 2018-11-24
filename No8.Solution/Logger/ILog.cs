//-----------------------------------------------------------------------
// <copyright file="ILog.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;

namespace No8.Solution
{
    /// <summary>
    /// Interface that all loggers must have
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="message">
        /// Some information
        /// </param>
        void Info(string message);

        /// <summary>
        /// Log errors
        /// </summary>
        /// <param name="message">
        /// Error information
        /// </param>
        void Error(string message);
    }
}
