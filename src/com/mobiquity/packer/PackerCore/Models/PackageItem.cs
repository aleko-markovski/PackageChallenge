﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Packer.Models
{
    /// <summary>
    /// PackageItem can be defined as struct for the need of this library since: 
    /// It logically represents a single value, similar to primitive types.
    /// It is immutable.
    /// </summary>
    public struct PackageItem
    {
        public int Index { get; set; }
        public double Weight { get; set; }
        public int Cost { get; set; }

        public PackageItem(int index, double weight, int cost)
        {
            Index = index;
            Weight = weight;    
            Cost = cost;
        }

        public override string ToString()
        {
            return $"({Index},{Weight},{Cost})";
        }
    }
}
