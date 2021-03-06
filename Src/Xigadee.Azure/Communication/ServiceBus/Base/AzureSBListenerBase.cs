﻿#region Copyright
// Copyright Hitachi Consulting
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

#region using
using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
#endregion
namespace Xigadee
{
    /// <summary>
    /// This is the abstract listener base.
    /// </summary>
    public abstract class AzureSBListenerBase<C, M> : MessagingListenerBase<C, M, AzureClientHolder<C, M>>
        , IAzureServiceBusMessagingService<ListenerPartitionConfig>
        where C : ClientEntity
    {
        #region AzureConn
        /// <summary>
        /// This is the Azure connection class.
        /// </summary>
        public AzureConnection AzureConn { get; set; }
        #endregion
        #region IsDeadLetterListener
        /// <summary>
        /// This property identifies whether the listener is a deadletter listener.
        /// </summary>
        public bool IsDeadLetterListener
        {
            get;
            set;
        } 
        #endregion

        #region ClientCreate()
        /// <summary>
        /// This method sets the start and stop listener methods.
        /// </summary>
        /// <returns>The client.</returns>
        protected override AzureClientHolder<C, M> ClientCreate(ListenerPartitionConfig partition)
        {
            var client = base.ClientCreate(partition);

            client.ClientClose = () => 
            {
                if (client.Client != null)
                    client.Client.Close();
            };
          
            return client;
        }
        #endregion

        /// <summary>
        /// This override is used to validate the listener configuration settings on startup.
        /// </summary>
        protected override void SettingsValidate()
        {
            if (AzureConn == null)
                throw new StartupMessagingException("AzureConn", "AzureConn cannot be null");

            base.SettingsValidate();
        }

    }
}
