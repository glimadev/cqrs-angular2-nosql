﻿using cqrs_angular2_nosql.Domain.Core.Events;
using FluentValidation.Results;
using System;

namespace cqrs_angular2_nosql.Domain.Core.Commands
{
    /// <summary>
    /// Model base de um comando
    /// </summary>
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
