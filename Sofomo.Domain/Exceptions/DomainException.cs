﻿namespace Sofomo.Domain.Exceptions
{

    using System;

    public class NotFoundException : Exception
    {

        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}