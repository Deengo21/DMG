using Microsoft.AspNetCore.Mvc;

namespace dmg.Controllers;



[ApiController]
[Route("characters")]
public class CharacterController : ControllerBase
{

    private List<Character> characters = new List<Character> {
         new Character{ Name = "Thomas", MeleCombat = 50, Shooting = 50,Strength= 20},
         new Character{ Name = "Gor", MeleCombat = 20, Shooting = 50,Strength= 20},
         new Character{ Name = "Arnold", MeleCombat = 30, Shooting = 50,Strength= 20},
    };

    private readonly ILogger<CharacterController> _logger;

    public CharacterController(ILogger<CharacterController> logger)
    {
        _logger = logger;
    }

    [HttpGet( )]
    public List<Character> Get()
    {
    return characters;

    }

    [HttpGet("{name}")]
    public Character GetCharacterByName(string name)
    {
        Character? character = characters.Find((character) => character.Name == name);
        if(character != null) {
            return character;
        }

        throw new Exception("Cahracter not found");
    }
}
