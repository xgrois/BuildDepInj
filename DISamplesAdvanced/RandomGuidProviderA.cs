using System;

namespace BuildDepInj.DISamplesAdvanced
{
    public class RandomGuidProviderA : IRandomGuidProvider
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}