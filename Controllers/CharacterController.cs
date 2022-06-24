using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace dmg.Controllers;

[ApiController]
[Route("characters")]
public class CharacterController : ControllerBase
{
    private List<Character> characters = new()
    {
        new Character { Name = "Thomas", MeleCombat = 50, Shooting = 50, Strength = 20 },
        new Character { Name = "Gor", MeleCombat = 20, Shooting = 50, Strength = 20 },
        new Character { Name = "Arnold", MeleCombat = 30, Shooting = 50, Strength = 20 },
    };

    private readonly ILogger<CharacterController> _logger;

    public CharacterController(ILogger<CharacterController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public List<Character> GetAll()
    {
        return characters;
    }

    [HttpGet("{name}")]
    public Character GetCharacterByName(string name)
    {
        var character = characters.Find((character) => character.Name == name);

        if (character == null)
        {
            throw new HttpRequestException("Character not found", null, HttpStatusCode.NotFound);
        }

        return character;
    }

    [HttpPost()]
    public List<Character> AddCharacter(Character character)
    {
        return characters.Append(character).ToList();
    }

    [HttpDelete("{name}")]
    public List<Character> DeleteByName(string name)
    {
        var character = characters.Find((character) => character.Name == name);
        if (character == null)
        {
            throw new HttpRequestException("Character not found", null, HttpStatusCode.NotFound);
        }

        characters.Remove(character);
        
        return characters;
    }

    [HttpPatch("{name}")]
    public List<Character> UpdateByName(string name, Character character)
    {
        var foundCharacterIndex = characters.FindIndex(c => c.Name == name);

        characters[foundCharacterIndex] = character;

        return characters;
    }
}