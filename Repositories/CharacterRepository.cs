using dmg.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
        var entity = await context.Set<Character>();
     
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
        List<Character> characters =  await context.Set<Character>().ToListAsync();
        List<int> weaponIds = new List<int>();
        for (int i = 0; i < characters.Count; i++)
        {
            Character character = characters[i];
            
            weaponIds.Add(character.WeaponId);
        }
        // Liste broni
        List<Weapon> weapons = new List<Weapon>();
        // Petla do pobierania broni
        for (int i = 0; i < weaponIds.Count; i++)
        {
           Weapon weapon = await context.Set<Weapon>().FindAsync(weaponIds[i]);

            weapons.Add(weapon);

        }

        return characters;



    }

    public async Task<Character> Update(Character entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
        
    }
    
}