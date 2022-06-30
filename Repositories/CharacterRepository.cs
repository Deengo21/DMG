using dmg.Data;
using Microsoft.EntityFrameworkCore;

namespace dmg.Repositories;

public class CharacterRepository : IRepository<Character>
{
    private readonly DbContext context;

    public CharacterRepository(DbContext context)
    {
        this.context = context;
    }

    public async Task<Character> Add(Character entity)
    {
        context.Set<Character>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<Character> Delete(int id)
    {
        var entity = await context.Set<Character>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        context.Set<Character>().Remove(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<Character> Get(int id)
    {
        return await context.Set<Character>().FindAsync(id);
    }

    public async Task<List<Character>> GetAll()
    {
        return await context.Set<Character>().ToListAsync();
    }

    public async Task<Character> Update(Character entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }
}