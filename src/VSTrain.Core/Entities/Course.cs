using System;
using VSTrain.Core.Common;

namespace VSTrain.Core.Entities
{
    public class Course: Base
    {
       public string Name { get; set; }
       public DateTimeOffset date {get; set;}
    }
}