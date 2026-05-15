using ProjetSGBD_part1_THIJSSEN_LOIC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSGBD_part1_THIJSSEN_LOIC.Présentation
{
    public class MenuContact
    {
        private readonly ContactRepository _contactRepository;
        
        public MenuContact(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
    }
}
