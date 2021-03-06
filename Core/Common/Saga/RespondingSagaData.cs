﻿using System;
using NServiceBus.Saga;

namespace Common.Saga
{
#if(Version3)

    public class RespondingSagaData : ISagaEntity
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
        public Guid MessageId { get; set; }
    }

#endif
#if(Version4 || Version5 || Version6)

    public class RespondingSagaData : IContainSagaData
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
        public Guid MessageId { get; set; }
    }

#endif
}