using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class EntityBase
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
