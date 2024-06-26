﻿using CoffeeStore.Domain.EF;
using CoffeeStore.Domain.Entities;
using CoffeeStore.Domain.Interfaces;
using System;
using System.Data.Entity;

namespace CoffeeStore.Domain.Repositories
{
    public class ClientManager : IClientManager
    {
        public EF.AppContext DataBase { get; set; }   
        public ClientManager(EF.AppContext dataBase) {  DataBase = dataBase; }

        public void Create(ClientProfile item)
        {
           DataBase.ClientProfiles.Add(item);
           DataBase.SaveChanges(); 
        }
        public void Delete(ClientProfile item)
        {
            DataBase.ClientProfiles.Remove(item);

        }
        public void Dispose()
        {
           DataBase.Dispose();
        }

        public void UpdateClientProfile(ClientProfile item)
        {
            var existingItem = DataBase.ClientProfiles.Find(item.Id);
            if (existingItem != null)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    existingItem.Name = item.Name;
                }

                if (!string.IsNullOrEmpty(item.Address))
                {
                    existingItem.Address = item.Address;
                }

                // Optionally, you can add more checks for other properties

                DataBase.Entry(existingItem).State = EntityState.Modified;
                DataBase.SaveChanges();
            }
        }


        public ClientProfile GetClientProfileById(string Id)
        {
            var client = DataBase.ClientProfiles.Find(Id);
            if(client != null) return client;
            return null;
        }
    }
}
