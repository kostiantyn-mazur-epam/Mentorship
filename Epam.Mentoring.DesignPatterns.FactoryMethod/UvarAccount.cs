﻿using System;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod
{
    public sealed class UvarAccount
    {
        public UvarAccount(int id, string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Id = id;
            Name = name;
        }

        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
    }
}