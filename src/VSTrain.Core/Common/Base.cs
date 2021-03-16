using System;

namespace VSTrain.Core.Common
{
    public class Base
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn {get;set;}
        public DateTimeOffset? LastModifiedOn {get;set;}
    }
}