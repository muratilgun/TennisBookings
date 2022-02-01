﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TennisBookings.Merchandise.Api.IntegrationTests.TestHelpers
{
    public class JsonSerializerHelper
    {
        public static JsonSerializerOptions DefaultSerialisationOptions => new JsonSerializerOptions
        {
            IgnoreNullValues = true
        };

        public static JsonSerializerOptions DefaultDeserialisationOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
