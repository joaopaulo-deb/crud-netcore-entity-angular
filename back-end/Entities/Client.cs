using System;
using System.Collections.Generic;

namespace Entities
{
    public abstract class Client
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Classification { get; set; }
        public string Cep { get; set; }
        public IEnumerable<Telephone> Telephones { get; set; }
    }
}
