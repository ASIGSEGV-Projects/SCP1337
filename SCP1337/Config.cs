﻿using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP1337
{
    public sealed class Config : IConfig
    {
        // Required
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        // Other...
        [Description("[IN PERCENTAGE (0-100%)] The probability that a player gets SCP-1337, drawn once per player that gets SCP, per round")]
        public float SpawnProbability { get; set; } = 100;
    }
}