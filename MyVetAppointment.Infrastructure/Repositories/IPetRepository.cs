﻿using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Infrastructure.Repositories
{
    public interface IPetRepository
    {
        Task AddAsync(Pet pet);
        void Delete(Guid id);
        Task<Pet?> GetByIdAsync(Guid id);
        Pet? GetPetId(Guid id, String name);
        Task<IReadOnlyCollection<Pet>> GetAllAsync();
        Task<IReadOnlyCollection<Pet>> GetPetsClient(Guid id);
        Task<IReadOnlyCollection<Appointment>> GetAppointmentsAsync(Guid id);
        void Save();
        void Update(Pet pet);
    }
}