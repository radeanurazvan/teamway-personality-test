using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Teamway.PersonalityTest.Domain;
using Entity = Teamway.PersonalityTest.Domain.Entity;

namespace Teamway.PersonalityTest.Persistence
{
    internal class InMemoryRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ICollection<T> items = new List<T>();

        public InMemoryRepository()
        {
            items = GetInitialState().ToList();
        }
        
        public IEnumerable<T> GetAll() => items;

        public Maybe<T> GetOne(Func<T, bool> predicate) => items.TryFirst(predicate);

        public void Add(T instance) => items.Add(instance);

        public void SaveChanges()
        {
        }

        protected virtual IEnumerable<T> GetInitialState() => new List<T>();
    }
}