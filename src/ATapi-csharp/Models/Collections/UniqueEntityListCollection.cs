﻿// The MIT License (MIT)

// Copyright (c) 2015 Ben Abelshausen

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;

namespace ATapi_csharp.Models.Collections
{
    /// <summary>
    /// A collection of GTFS-entities that can be identified by an ID based on a list.
    /// </summary>
    public class UniqueEntityListCollection<T> : IUniqueEntityCollection<T>
        where T : GTFSEntity
    {
        /// <summary>
        /// Holds the list containing all stops.
        /// </summary>
        private List<T> _entities;

        /// <summary>
        /// Holds the function to match ID's.
        /// </summary>
        private Func<T, string, bool> _hasId;

        /// <summary>
        /// Creates a unique entity collection based on a list.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="hasId"></param>
        public UniqueEntityListCollection(List<T> entities, Func<T, string, bool> hasId)
        {
            _entities = entities;
            _hasId = hasId;
        }

        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        /// <summary>
        /// Gets the entity with the given id.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public T Get(string entityId)
        {
            foreach(var entity in _entities)
            {
                if(_hasId(entity, entityId))
                {
                    return entity;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Gets the entity at the given index.
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public T Get(int idx)
        {
            return _entities[idx];
        }

        /// <summary>
        /// Removes the entity with the given id.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public bool Remove(string entityId)
        {
            for (int idx = 0; idx < _entities.Count; idx++)
            {
                var stop = _entities[idx];
                if (_hasId(stop, entityId))
                {
                    _entities.RemoveAt(idx);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns all entities.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Get()
        {
            return _entities;
        }

        /// <summary>
        /// Returns the number of entities.
        /// </summary>
        public int Count
        {
            get { return _entities.Count; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the entities.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the entities.
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _entities.GetEnumerator();
        }
    }
}