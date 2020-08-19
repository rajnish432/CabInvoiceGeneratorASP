// <copyright file="CabInvoiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    using System;

    public class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_USER_ID,
        }

        public ExceptionType exceptionType;

        public CabInvoiceException(string message, ExceptionType exceptionType)
            : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
