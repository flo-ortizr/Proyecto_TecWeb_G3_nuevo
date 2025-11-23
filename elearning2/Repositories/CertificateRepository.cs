using Microsoft.EntityFrameworkCore;
using elearning2.Data;
using elearning2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace elearning2.Repositories
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly AppDbContext _db;

        public CertificateRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Certificate>> GetAll()
        {
            return await _db.Certificates.ToListAsync();
        }

        public async Task<Certificate?> GetOne(Guid id)
        {
            return await _db.Certificates.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Add(Certificate certificate)
        {
            await _db.Certificates.AddAsync(certificate);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Certificate certificate)
        {
            _db.Certificates.Update(certificate);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Certificate certificate)
        {
            _db.Certificates.Remove(certificate);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Certificate>> GetByStudentId(Guid studentId)
        {
            return await _db.Certificates
                .Where(c => c.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<Certificate?> GetByTitle(string title)
        {
            return await _db.Certificates.FirstOrDefaultAsync(c => c.Title == title);
        }
    }
}
