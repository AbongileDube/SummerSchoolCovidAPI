﻿using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;
using SummerSchoolCovidAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SummerSchoolCovidAPI.Services
{
    public class CovidCaseContactService : ICovidCaseContactService
    {
        private readonly CovidDbContext _context;

        public CovidCaseContactService(CovidDbContext context)
        {
            _context = context;
        }

        public async Task<CovidCaseContact> AddCovidCaseContact(CovidCaseContactDto covidCaseContact)
        {
            var obj = new CovidCaseContact
            {
                Name = covidCaseContact.Name,
                Surname = covidCaseContact.Surname,
                Email = covidCaseContact.Email,
                MobileNumber = covidCaseContact.MobileNumber,
                LocationId = covidCaseContact.LocationId,
                InfectedUserId = covidCaseContact.InfectedUserId,
                CovidCaseId = covidCaseContact.CovidCaseId,
                Id = covidCaseContact.Id,
            };
            var entityAdded = await _context.CovidCaseContacts.AddAsync(obj);
            await _context.SaveChangesAsync();
            return entityAdded.Entity;
        }

        public async Task DeleteCovidCaseContact(string id)
        {
            var entity = await _context.CovidCaseContacts.FindAsync(id);
            _context.CovidCaseContacts.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<CovidCaseContact> GetCovidCaseContact(string id)
        {
            return await _context.CovidCaseContacts.FindAsync(id);
        }

        public async Task<IEnumerable<CovidCaseContact>> GetCovidCaseContact()
        {
            return await _context.CovidCaseContacts.ToListAsync();
        }

        public async Task<IEnumerable<CovidCase>> GetCovidCaseContacts()
        {
            return await _context.CovidCases.ToListAsync();
        }

        public async Task<List<CovidCaseContact>> UpdateCovidCaseContact(string id, CovidCaseContactDto covidCase)
        {
            return await _context.CovidCaseContacts.ToListAsync();
        }

        public async Task<CovidCaseContact> UpdateCovidCaseContact(string id)
        {
            var entity = await _context.CovidCaseContacts.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Given Id:'{id}' is not found");
            }
            return entity;
        }
    }
}