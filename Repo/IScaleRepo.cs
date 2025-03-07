using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarAPI.Models;

namespace GuitarAPI.Repo
{
    public interface IScaleRepo
    {
        Task CreateAsync(Scale scale);
        Task<IEnumerable<Scale>> GetAllAsync();
        Task<Scale?> GetByNameAsync(string name);
    }
}