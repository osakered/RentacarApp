using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApp.Models
{
    /// <summary>
    /// Подключение базы данных
    /// </summary>
    public class Core
    {
        public RentacarDBEntities context = new RentacarDBEntities(); 
    }
}