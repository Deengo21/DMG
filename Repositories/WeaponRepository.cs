using dmg.Data;
using Microsoft.EntityFrameworkCore;

namespace dmg.Repositories;

public class WeaponRepository : IRepository<Weapon>
{
    private readonly DbContext context;

    public WeaponRepository(DbContext context)
    {
        this.context = context;
    }

    public async Task<Weapon> Add(Weapon entity)
    {
        context.Set<Weapon>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<Weapon> Delete(int id)
    {
        var entity = await context.Set<Weapon>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        context.Set<Weapon>().Remove(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<Weapon> Get(int id)
    {
        return await context.Set<Weapon>().FindAsync(id);
    }

    public async Task<List<Weapon>> GetAll()
    {
        return await context.Set<Weapon>().ToListAsync();
    }

    public async Task<Weapon> Update(Weapon entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }
}