using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class UserRepository : IUserRepository
{
    private readonly DefaultDbContext _dbContext;

    public UserRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(User entity)
    {
        User? user = await Get(entity.Id);

        if (user != null) 
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(User)}> and Id <{entity.Id}> already exists");
        }

        _dbContext.Users.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> Get(Guid Id)
    {
        User? user = await _dbContext.Users.Where(usr => usr.Id == Id).FirstOrDefaultAsync();
        return user;
    }
    
    public async Task<User?> GetByEmail(string email)
    {
        User? user = await _dbContext.Users.Where(usr => usr.Email == email).FirstOrDefaultAsync();
        return user;
    }

    public Task<IQueryable<User>> GetAll()
    {
        return Task.FromResult(_dbContext.Users.AsQueryable());
    }

    public Task Update(User entity)
    {
        throw new NotImplementedException();
    }
}