using Hotel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Business.Interfaces
{
    public interface IClientBusiness
    {
        ClientEntity Insert(ClientEntity client);
    }
}
