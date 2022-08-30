using Microsoft.EntityFrameworkCore;
using ProiectASP.DAL.Models;
using ProiectASP.DAL.Entities;
using ProiectASP.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Repositories
{
    public class InfoRepository : IInfoRepository
    {
        private readonly AppDbContext appDbContext;

        public InfoRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public async Task Create(Info info)
        {
            await appDbContext.Infos.AddAsync(info);
            await appDbContext.SaveChangesAsync();
        }
        public async Task Update(Info desc)
        {
            appDbContext.Infos.Update(desc);
            await appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Info info)
        {
            appDbContext.Remove(info);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<InfoModel>> GetAll()
        {
            var infos = await GetAllQuery().ToListAsync();
            var list = new List<InfoModel>();
            foreach (var info in infos)
            {
                var infoModel = new InfoModel
                {
                    Id = info.Id,
                    Information = info.Information,
                    LastUpdate = info.LastUpdate
                };
                list.Add(infoModel);
            }
            return list;
        }
        public IQueryable<Info> GetAllQuery()
        {
            var query = appDbContext.Infos.AsQueryable();
            return query;
        }

        public async Task<Info> GetById(int id)
        {
            var info = await appDbContext.Infos.FindAsync(id);
            return info;
        }
    }
}
