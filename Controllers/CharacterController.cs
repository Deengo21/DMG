using System.Net;
using dmg.Data;
using dmg.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dmg.Controllers;

[ApiController]
[Route("weapons")]
public class WeaponController : ControllerBase
{
    private readonly ILogger<WeaponController> _logger;

    private readonly IRepository<Weapon> _weaponRepository;

    public WeaponController(ILogger<WeaponController> logger, IRepository<Weapon> weaponRepository)
    {
        _logger = logger;
        _weaponRepository = weaponRepository;
    }

    [HttpGet()]
    public async Task<List<Weapon>> GetAll()
    {
        return await this._weaponRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Weapon> GetWeaponByName(int id)
    {
        var weapon = await this._weaponRepository.Get(id);

        if (weapon == null)
        {
            throw new HttpRequestException("Weapon not found", null, HttpStatusCode.NotFound);
        }

        return weapon;
    }

    [HttpPost()]
    public async Task<Weapon> AddWeapon(Weapon weapon)
    {
    //   Weapons.Push(new Weapon());
    // Dodawanie postaci

        return await this._weaponRepository.Add(weapon);
    }

    [HttpDelete("{id}")]
    public async Task<Weapon> DeleteByName(int id)
    {
        return await this._weaponRepository.Delete(id);
    }

    [HttpPatch("{id}")]
    public async Task<Weapon> UpdateByName(Weapon weapon)
    {
        return await this._weaponRepository.Update(weapon);
    }
}