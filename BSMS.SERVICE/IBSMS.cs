using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSMS.SERVICE.App_Data;
namespace BSMS.SERVICE
{
    interface IBSMS
    {
        List<USER> GetUsers();
        List<ROLE> GetRoles();

        bool AddUser(USER user);
    }
    
}
