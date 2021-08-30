using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLinkDataModel.Services
{
    public interface IGenric <T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(List<T> obja , T obj);
        int Update(T[] obja, T obj);
    }
}
