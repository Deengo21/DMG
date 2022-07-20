using System.Net;
using dmg.Data;
using dmg.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dmg.Controllers;

[ApiController]
[Route("characters")]
public class CharacterController : ControllerBase
{
    private readonly ILogger<CharacterController> _logger;

    private readonly IRepository<Character> _characterRepository;

    public CharacterController(ILogger<CharacterController> logger, IRepository<Character> characterRepository)
    {
        _logger = logger;
        _characterRepository = characterRepository;
    }

    [HttpGet()]
    public async Task<List<Character>> GetAll()
    {
        return await this._characterRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Character> GetCharacterByName(int id)
    {
        var character = await this._characterRepository.Get(id);

        if (character == null)
        {
            throw new HttpRequestException("Character not found", null, HttpStatusCode.NotFound);
        }

        return character;
    }

    [HttpPost()]
    public async Task<Character> AddCharacter(Character character)
    {
    //   Characters.Push(new Character());
    // Dodawanie postaci

        return await this._characterRepository.Add(character);
    }

    [HttpDelete("{id}")]
    public async Task<Character> DeleteByName(int id)
    {
        return await this._characterRepository.Delete(id);
    }

    [HttpPatch("{id}")]
    public async Task<Character> UpdateByName(Character character)
    {
        return await this._characterRepository.Update(character);
    }
}