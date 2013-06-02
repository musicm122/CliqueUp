using System;
using System.Collections.Generic;

namespace CliqueUpModel.Model
{
    
    public class Category
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public virtual List<CategoryEvent> Events { get; set; }
    }
}
