using System;
using System.Collections.Generic;

namespace Hotel.Domain.Models
{
    /// <summary>
    /// Classe abstrata responsável por garantir a herença das propriedades em suas entidades
    /// </summary>
    public abstract class Entity
    {
        protected Entity()
        {
            Validations = new List<string>();
        }
        public int Id { get; set; }
        public Guid Key { get; set; }
        public List<string> Validations { get; set; }
    }
}
