using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRoomService:IBaseBusiness<SYS_ROOMINFO>
    {
        List<AreaBook> AreaBook(int areaid, string connectionString);
    }
}
