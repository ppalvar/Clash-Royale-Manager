using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IClanRepository 
{
    Task Create(Clan entity);
    Task Update(Clan entity);
    Task Remove(Guid Id);
    Task<(Clan? Clan, string Type)?> Get(Guid Id);
    Task<IQueryable<ClanTypeInfo>> GetAll();
    Task<Clan?> Get1(Guid Id);

    Task<(Clan? Clan, string Type)?> GetBestRegion(int region);
    Task<(IQueryable<ClanTypeInfo> Clans, int Page, int TotalPages)> GetPagination(int page = 1, int size = 10);
}

public class ClanTypeInfo
{
    public Clan? Clan { get; set; }
    public string Type { get; set; }
}