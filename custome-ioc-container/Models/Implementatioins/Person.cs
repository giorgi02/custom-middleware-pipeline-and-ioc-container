using custome_ioc_container.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace custome_ioc_container.Models.Implementatioins
{
    public class Person : IPerson
    {
        private Guid Key = Guid.NewGuid();

        public override string ToString()
        {
            return this.Key.ToString();
        }
    }
}
