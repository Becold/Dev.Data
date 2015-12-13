﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Apps72.Dev.Data
{
    /// <summary>
    /// Base Interface to manage all DataBaseCommands
    /// </summary>
    public interface IDatabaseCommandBase : IDisposable
    {

        /// <summary>
        /// Gets or sets the sql query
        /// </summary>
        System.Text.StringBuilder CommandText { get; set; }

        /// <summary>
        /// Gets or sets the command type
        /// </summary>
        System.Data.CommandType CommandType { get; set; }

        /// <summary>
        /// Gets or sets the current transaction
        /// </summary>
        IDbTransaction Transaction { get; set; }

        /// <summary>
        /// Gets sql parameters of the query
        /// </summary>
        IDataParameterCollection Parameters { get; }

        /// <summary>
        /// Enable or disable the raise of exceptions when queries are executed.
        /// Default is True (Enabled).
        /// </summary>
        bool ThrowException { get; set; }

        /// <summary>
        /// Gets the last raised exception 
        /// </summary>
        System.Runtime.InteropServices.ExternalException Exception { get; }

        /// <summary>
        /// Set this property to log the SQL generated by this class to the given delegate. 
        /// For example, to log to the console, set this property to Console.Write.
        /// </summary>
        Action<string> Log { get; set; }

        /// <summary>
        /// Delete the CommandText and the all sql parameters
        /// </summary>
        void Clear();

        /// <summary>
        /// Prepare a query
        /// </summary>
        void Prepare();

        /// <summary>
        /// Begin a transaction into the database
        /// </summary>
        /// <returns>Transaction</returns>
        IDbTransaction TransactionBegin();

        /// <summary>
        /// Commit the current transaction to the database
        /// </summary>
        void TransactionCommit();

        /// <summary>
        /// Rollback the current transaction 
        /// </summary>
        void TransactionRollback();

        /// <summary>
        /// Execute query and return results by using a Datatable
        /// </summary>
        /// <returns>DataTable of results</returns>
        System.Data.DataTable ExecuteTable();

        /// <summary>
        /// Execute the query and return an array of new instances of typed results filled with data table result.
        /// </summary>
        /// <typeparam name="TReturn">Object type</typeparam>
        /// <returns>Array of typed results</returns>
        /// <example>
        /// <code>
        ///   Employee[] emp = cmd.ExecuteTable&lt;Employee&gt;();
        ///   var x = cmd.ExecuteTable&lt;Employee&gt;();
        /// </code>
        /// <remarks>
        ///   Result object property (ex. Employee.Name) may be tagged with the ColumnAttribute 
        ///   to set which column name (ex. [Column("Name")] must be associated to this property.
        /// </remarks>
        /// </example>
        IEnumerable<TReturn> ExecuteTable<TReturn>();

        /// <summary>
        /// Execute the query and return an array of new instances of typed results filled with data table result.
        /// </summary>
        /// <typeparam name="TReturn">Object type</typeparam>
        /// <param name="itemOftype"></param>
        /// <returns>Array of typed results</returns>
        /// <example>
        /// <code>
        ///   Employee emp = new Employee();
        ///   var x = cmd.ExecuteTable(new { emp.Age, emp.Name });
        ///   var y = cmd.ExecuteTable(new { Age = 0, Name = "" });
        /// </code>
        /// <remarks>
        ///   Result object property (ex. Employee.Name) may be tagged with the ColumnAttribute 
        ///   to set which column name (ex. [Column("Name")] must be associated to this property.
        /// </remarks>
        /// </example>
        IEnumerable<TReturn> ExecuteTable<TReturn>(TReturn itemOftype);

        /// <summary>
        /// Execute the query and return an array of new instances of typed results filled with data table result.
        /// </summary>
        /// <typeparam name="TReturn">Object type</typeparam>
        /// <param name="converter">Conveter method to return a typed object from DataRow</param>
        /// <returns>Array of typed results</returns>
        IEnumerable<TReturn> ExecuteTable<TReturn>(Func<System.Data.DataRow, TReturn> converter);

        /// <summary>
        /// Execute the query and return the count of modified rows
        /// </summary>
        /// <returns>Count of modified rows</returns>
        int ExecuteNonQuery();

        /// <summary>
        /// Execute the query and return the first column of the first row of results
        /// </summary>
        /// <returns>Object - Result</returns>
        object ExecuteScalar();

        /// <summary>
        /// Execute the query and return the first column of the first row of results
        /// </summary>
        /// <typeparam name="TReturn">Return type</typeparam>
        /// <returns>Result</returns>
        TReturn ExecuteScalar<TReturn>();

        /// <summary>
        /// Execute the query and return the first row of results    
        /// </summary>
        /// <returns>First row of results</returns>
        System.Data.DataRow ExecuteRow();

        /// <summary>
        /// Execute the query and return a new instance of TReturn with the first row of results
        /// </summary>
        /// <typeparam name="TReturn">Object type</typeparam>
        /// <returns>First row of results</returns>
        /// <example>
        /// <code>
        ///   Employee emp = cmd.ExecuteRow&lt;Employee&gt;();
        /// </code>
        /// <remarks>
        ///   Result object property (ex. Employee.Name) may be tagged with the ColumnAttribute 
        ///   to set which column name (ex. [Column("Name")] must be associated to this property.
        /// </remarks>
        /// </example>
        TReturn ExecuteRow<TReturn>();

        /// <summary>
        /// Execute the query and fill the specified TReturn object with the first row of results
        /// </summary>
        /// <typeparam name="TReturn">Object type</typeparam>
        /// <param name="itemOftype"></param>
        /// <returns>First row of results</returns>
        /// <example>
        /// <code>
        ///   Employee emp = new Employee();
        ///   var x = cmd.ExecuteRow(new { emp.Age, emp.Name });
        ///   var y = cmd.ExecuteRow(new { Age = 0, Name = "" });
        ///   var z = cmd.ExecuteRow(emp);
        /// </code>
        /// <remarks>
        ///   Result object property (ex. Employee.Name) may be tagged with the ColumnAttribute 
        ///   to set which column name (ex. [Column("Name")] must be associated to this property.
        /// </remarks>
        /// </example>
        TReturn ExecuteRow<TReturn>(TReturn itemOftype);

        /// <summary>
        /// Execute the query and fill the specified TReturn object with the first row of results
        /// </summary>
        /// <typeparam name="TReturn">Object type</typeparam>
        /// <param name="converter">Conveter method to return a typed object from DataRow</param>
        /// <returns>First row of results</returns>
        TReturn ExecuteRow<TReturn>(Func<System.Data.DataRow, TReturn> converter);
    }
}
