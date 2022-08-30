using ProiectASP.BLL.Interfaces;
using ProiectASP.DAL.Entities;
using ProiectASP.DAL.Interfaces;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Managers
{
    public class InfoManager : IInfoManager
    {
        private readonly IInfoRepository infoRepo;

        public InfoManager(IInfoRepository repo)
        {
            infoRepo = repo;
        }

        public async Task CreateInfo(InfoModel model)
        {
            var information = new Info
            {
                Information = model.Information,
                LastUpdate = DateTime.Now
            };

            await infoRepo.Create(information);
        }

        public async Task<int> DeleteInfo(int id)
        {
            var information = await infoRepo.GetById(id);
            if (information == null)
            {
                return -1;
            }

            await infoRepo.Delete(information);
            return 1;
        }

        public async Task<List<InfoModel>> GetAll()
        {
            var infos = await infoRepo.GetAll();
            return infos;
        }

        public async Task UpdateInfo(InfoModel model)
        {
            var information = await infoRepo.GetById(model.Id);
            if (information == null)
            {
                throw new Exception();
            }

            information.Information = model.Information;
            information.LastUpdate = DateTime.Now;

            await infoRepo.Update(information);
        }

        public async Task<InfoModel> GetById(int id)
        {
            var information = infoRepo.GetAllQuery().FirstOrDefault(x => x.Id == id);
            if (information == null)
                throw new Exception();
            var model = new InfoModel
            {
                Id = information.Id,
                Information = information.Information,
                LastUpdate = information.LastUpdate
            };

            return model;
        }
    }
}
