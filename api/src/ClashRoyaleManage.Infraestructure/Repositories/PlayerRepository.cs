using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class PlayerRepository : IPlayerRepository
{
    private readonly DefaultDbContext _dbContext;

    public PlayerRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Player entity)
    {
        Player? player = await Get(entity.Id);

        if (player != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Player)}> and Id <{entity.Id}> already exists");
        }

        _dbContext.Players.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Player?> Get(Guid Id)
    {
        Player? player = await _dbContext.Players.Where(cd => cd.Id == Id).FirstOrDefaultAsync();
        return player;
    }

    public Task<IQueryable<Player>> GetAll()
    {
        return Task.FromResult(_dbContext.Players.AsQueryable());
    }

    public async Task<(IQueryable<Player> Players, int Page, int TotalPages)> GetBestInWar(Guid warId, int page = 1, int pageSize = 10)
    {

        var war = await _dbContext.Wars.Where(w => w.Id == warId)
                                           .Include(w => w.ClanWars)
                                           .FirstOrDefaultAsync();

        var clans = war!.ClanWars
                        .Select(c => _dbContext.Clans.Where(c_ => c_.Id == c.IdClan)
                                                     .Include(c_ => c_.PlayerClans)
                                                     .FirstOrDefault()!);

        var players = new List<Player>();
        foreach (Clan clan in clans)
        {
            Player player = clan.PlayerClans.Select(pc => _dbContext.Players.Find(pc.IdPlayer)!)
                                            .OrderByDescending(p => p.NumberOfTrophies)
                                            .First();
            players.Add(player);
        }

        var resp = Paginate(players.AsQueryable(), page, pageSize);

        return (resp, page, players.Count / pageSize);
    }

    public Task<(IQueryable<Player> Players, int Page, int TotalPages)> GetPagination(int page, int size)
    {
        int skipCount = (page - 1) * size;
        int cantElements = size;
        int totalElements = _dbContext.Players.Count();
        int totalPages = (int)Math.Ceiling((double)totalElements / size);

        if (page == totalPages && totalElements % size != 0)
        {
            cantElements = totalElements % size;
        }
        var _players = _dbContext.Players
        .OrderBy(cd => cd.Id)
        .Skip(skipCount)
        .Take(cantElements);

        return Task.FromResult((_players, page, totalPages));
    }

    public async Task Remove(Guid Id)
    {
        Player? player = await Get(Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Player)}> and Id <{Id}> not exists");

        _dbContext.Players.Remove(player);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Player entity)
    {
        Player? player = await Get(entity.Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Player)}> and Id <{entity.Id}> not exists");

        _dbContext.Players.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<(IQueryable<Clan> Clans, int Page, int TotalPages)> GetClansCanJoin(Guid playerId, int page = 1, int size = 10)
    {
        var player = (await _dbContext.Players.FindAsync(playerId))!;

        var _clans = _dbContext.Clans.Where(c => c.TrophiesNeededToEnter <= player.NumberOfTrophies).AsNoTracking();
        var clans = Paginate(_clans, page, size);

        return (clans, page, _clans.Count() / size);
    }

    private static IQueryable<T> Paginate<T>(IQueryable<T> players, int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        return players.Skip(skip).Take(pageSize);
    }
}