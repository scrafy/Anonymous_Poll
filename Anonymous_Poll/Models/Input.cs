using System;
using System.Collections.Generic;

namespace Anonymous_Poll.Models
{
    public class Input
    {
        public ushort Total { get; set; }
        public List<InputCase> InputCases { get; set; }

        public Input()
        {
        }
    }
}
