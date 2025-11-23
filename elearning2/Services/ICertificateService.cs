using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using elearning2.Models;

namespace elearning2.Services
{
    public interface ICertificateService
    {
        Task<IEnumerable<Certificate>> GetAll();
        Task<Certificate?> GetOne(Guid id);
        Task Add(Certificate certificate);
        Task Update(Certificate certificate);
        Task Delete(Certificate certificate);
        Task<IEnumerable<Certificate>> GetByStudentId(Guid studentId);
        Task<Certificate?> GetByTitle(string title);
    }
}
