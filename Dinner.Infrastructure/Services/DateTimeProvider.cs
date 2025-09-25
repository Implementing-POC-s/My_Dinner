
using Dinner.Application.Common.Interfaces.Services;

namespace  Dinner.Infrastructure.Services;
using Dinner.Application.Common.Interfaces.Services;
using System;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

