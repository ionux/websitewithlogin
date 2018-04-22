using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteWithLogin.Models;

namespace WebsiteWithLogin.Contracts
{
    public interface IStudentRepository
    {
        List<StudentUser> GetAll();
    }
}