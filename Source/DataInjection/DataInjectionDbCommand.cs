﻿using System;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Apps72.Dev.Data
{
    /// <summary>
    /// Main properties used with current DatabaseCommand request.
    /// </summary>
    public class DataInjectionDbCommand
    {
        /// <summary>
        /// Initializes a new instance of DataInjection Database Command
        /// </summary>
        /// <param name="command"></param>
        internal DataInjectionDbCommand(DbCommand command)
        {
            this.CommandText = command.CommandText;
            this.CommandType = command.CommandType;
            this.Parameters = command.Parameters.Cast<DbParameter>().ToArray();
        }

        /// <summary>
        /// Get the CommandText used with this request.
        /// </summary>
        public string CommandText { get; private set; }

        /// <summary>
        /// Get the CommandType used with this request.
        /// </summary>
        public CommandType CommandType { get; private set; }

        /// <summary>
        /// Get all parameters used with this request.
        /// </summary>
        public DbParameter[] Parameters { get; private set; }
    }
}
