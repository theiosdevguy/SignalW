// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Spreads.SignalW.Client;
using Spreads.SignalW.Groups;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Spreads.SignalW
{
    public class Hub : IDisposable
    {
        private bool _disposed;
        private IHubConnectionContext _clients;
        private HubCallerContext _context;
        private GroupManager _groups;
        public Format Format { get; set; } = Format.Text;

        public IHubConnectionContext Clients
        {
            get
            {
                CheckDisposed();
                return _clients;
            }
            set
            {
                CheckDisposed();
                _clients = value;
            }
        }

        public HubCallerContext Context
        {
            get
            {
                CheckDisposed();
                return _context;
            }
            set
            {
                CheckDisposed();
                _context = value;
            }
        }

        public GroupManager Groups
        {
            get
            {
                CheckDisposed();
                return _groups;
            }
            set
            {
                CheckDisposed();
                _groups = value;
            }
        }

        public virtual Task OnConnectedAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnDisconnectedAsync(Exception exception)
        {
            return Task.CompletedTask;
        }

        public virtual ValueTask OnReceiveAsync(MemoryStream payload)
        {
            return new ValueTask();
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            Dispose(true);

            _disposed = true;
        }

        private void CheckDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}
