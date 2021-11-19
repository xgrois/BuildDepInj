using System;

namespace BuildDepInj.DISamplesAdvanced
{
    public interface IRandomGuidProvider
    {
        Guid RandomGuid { get; }
    }
}