using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Teamway.PersonalityTest.Domain
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();

        Maybe<T> GetOne(Func<T, bool> predicate);

        void Add(T instance);

        void SaveChanges();
    }
}