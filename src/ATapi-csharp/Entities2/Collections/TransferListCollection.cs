﻿using System.Collections.Generic;
using System.Linq;

namespace ATapi_csharp.Entities2.Collections
{
    /// <summary>
    /// Abstract representation of a collection of Transfer.
    /// </summary>
    public class TransferListCollection : ITransferCollection
    {
        /// <summary>
        /// Holds the tranfers.
        /// </summary>
        private List<Transfer> _transfers;

        /// <summary>
        /// Creates a new transfer list collection.
        /// </summary>
        /// <param name="transfers"></param>
        public TransferListCollection(List<Transfer> transfers)
        {
            _transfers = transfers;
        }
        /// <summary>
        /// Adds a new transfer.
        /// </summary>
        /// <param name="transfer"></param>
        public void Add(Transfer transfer)
        {
            _transfers.Add(transfer);
        }

        /// <summary>
        /// Gets all transfers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Transfer> Get()
        {
            return _transfers;
        }

        /// <summary>
        /// Gets all transfers for the given from stop.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Transfer> GetForFromStop(string stopId)
        {
            return _transfers.Where(x =>
                {
                    return x.FromStopId == stopId;
                });
        }

        /// <summary>
        /// Removes all transfers for the given from stop.
        /// </summary>
        /// <returns></returns>
        public int RemoveForFromStop(string stopId)
        {
            return _transfers.RemoveAll(x =>
            {
                return x.FromStopId == stopId;
            });
        }

        /// <summary>
        /// Gets all transfers for the given to stop.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Transfer> GetForToStop(string stopId)
        {
            return _transfers.Where(x =>
            {
                return x.ToStopId == stopId;
            });
        }

        /// <summary>
        /// Removes all transfers for the given to stop.
        /// </summary>
        /// <returns></returns>
        public int RemoveForToStop(string stopId)
        {
            return _transfers.RemoveAll(x =>
            {
                return x.ToStopId == stopId;
            });
        }

        /// <summary>
        /// Returns an enumerator that iterates through the entities.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Transfer> GetEnumerator()
        {
            return _transfers.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the entities.
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _transfers.GetEnumerator();
        }
    }
}
