using System;
namespace Anonymous_Poll.Models
{
    public class InputCase
    {
        public ushort Age { get; set; }
        public char Gender { get; set; }
        public string Studies { get; set; }
        public ushort AcademicYear { get; set; }

        public InputCase()
        {
        }
    }
}
