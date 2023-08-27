using Microsoft.AspNetCore.Mvc;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pukimoni.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarterController : ControllerBase
    {

        public PukimoniContext context;

        public StarterController(PukimoniContext pukimoniContext)
        {
            context = pukimoniContext;
        }

        // POST api/<StarterController>
        [HttpPost]
        public IActionResult Post()
        {

            if (context.Users.Any())
            {
                return Conflict();
            }

            //desava se ad nece normalno da mi unese stvari, pa da se ne bi pobrkali rucno unosim id za ovo i permissions
            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Admin",
                    Description = "This role can do everything."

                },
                new Role
                {
                    Name = "Trainer",
                    Description = "This role can only interact with Pokemon."

                }
            };

            foreach (var role in roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }

            var permissions = new List<Permission> {
                new Permission {
                    Name = "GetUsers",
                    Description = "Get all users"
                },
                new Permission {
                    Name = "GetUser",
                    Description = "Get a user"
                },
                new Permission {
                    Name = "GetRegions",
                    Description = "Get details of regions"
                },
                new Permission {
                    Name = "GetRegion",
                    Description = "Get details of a region"
                },
                new Permission {
                    Name = "GetPokemonsTrainers",
                    Description = "Get list of pokemon that a trainer has"
                },
                new Permission {
                    Name = "GetPokemons",
                    Description = "Get all pokemon"
                },
                new Permission {
                    Name = "GetPokemon",
                    Description = "Get a pokemonr"
                },
                new Permission {
                    Name = "GetElementTypes",
                    Description = "Get details of a pokemon types"
                },
                new Permission {
                    Name = "GetElementType",
                    Description = "Get details of a pokemon type"
                },
                new Permission {
                    Name = "UpdateUser",
                    Description = "Update a username and/or password"
                },
                new Permission {
                    Name = "UpdateRegion",
                    Description = "Update a region"
                },
                new Permission {
                    Name = "UpdatePokemon",
                    Description = "Update a pokemon"
                },
                new Permission {
                    Name = "UpdateElementType",
                    Description = "Update a pokemon type"
                },
                new Permission {
                    Name = "Transfer Pokemon",
                    Description = "Transfer a Pokemon to the professor"
                },
                new Permission {
                    Name = "FavoritePokemon",
                    Description = "Favorite pokemon toggle"
                },
                new Permission {
                    Name = "DeleteTrainer",
                    Description = "Delete a trainer"
                },
                new Permission {
                    Name = "DeleteRegion",
                    Description = "SoftDelete a region"
                },
                new Permission {
                    Name = "DeletePokemon",
                    Description = "SoftDelete a pokemon"
                },
                new Permission {
                    Name = "DeleteElementType",
                    Description = "SoftDelete a pokemon type"
                },
                new Permission {
                    Name = "CreateUser",
                    Description = "Create a trainer"
                },
                new Permission {
                    Name = "CreateRegion",
                    Description = "Create a new region"
                },
                new Permission {
                    Name = "CreatePokemon",
                    Description = "Create a pokemon"
                },
                new Permission {
                    Name = "CreateElementType",
                    Description = "Create a new pokemon type"
                },
                new Permission {
                    Name = "CatchPokemon",
                    Description = "Catch a pokemon"
                },
                new Permission {
                    Name = "BanUser",
                    Description = "Ban a user"
                },
                new Permission {
                    Name = "GetLogs",
                    Description = "Get all logs"
                }
            };

            foreach (var permission in permissions)
            {
                context.Permissions.Add(permission);
                context.SaveChanges();
            }
            //nzm koliko je pametno raditi ovo kroz for ali ima mnogo, ovako je lakse :(
            var rolePermissions = new List<RolePermission>();

            for (var i = 0; i < 26; i++) {
                rolePermissions.Add(new RolePermission
                {
                    Role = roles.First(),
                    Permission = permissions.ElementAt(i)
                });

                if ((i >= 1 && i <= 9) || i == 14 || i == 15 || i == 16 || i == 24)
                {
                    rolePermissions.Add(new RolePermission
                    {
                        Role = roles.Last(),
                        Permission = permissions.ElementAt(i)
                    });
                }
            };

            var starterTypes = new List<ElementType>
                {
                    new ElementType
                    {
                        Name = "Grass",
                        Description = "Grass-type moves are super-effective against Ground-, Rock-, and Water-type Pokémon, while Grass-type Pokémon are weak to Bug-, Fire-, Flying-, Ice-, and Poison-type moves."
                    },
                    new ElementType
                    {
                        Name = "Water",
                        Description = "Water-type moves are super-effective against Fire-, Ground-, and Rock-type Pokémon, while Water-type Pokémon are weak to Electric- and Grass-type moves"
                    },
                    new ElementType
                    {
                        Name = "Fire",
                        Description = "Fire-type moves are super-effective against Bug-, Grass-, Ice-, and Steel-type Pokémon, while Fire-type Pokémon are weak to Ground-, Rock-, and Water-type moves."
                    },
                    new ElementType
                    {
                        Name = "Poison",
                        Description = "Poison-type moves are super-effective against Fairy- and Grass-type Pokémon, while Poison-type Pokémon are weak to Ground- and Psychic-type moves."
                    }
                };

            var regions = new List<Region>
                {
                    new Region
                    {
                        Name = "Kanto",
                        Description = "The Kanto region is the setting of Pokémon Red, Blue, and Yellow and their remakes, Pokémon FireRed, LeafGreen, Let's Go, Pikachu! and Let's Go, Eevee!. Based on and named after the Kantō region of Japan, this setting started the precedent of basing the geography and culture of the game's region on a real-world setting. This region is also visited in Pokémon Gold, Silver, Crystal, HeartGold and SoulSilver."
                    },
                    new Region
                    {
                        Name = "Johto",
                        Description = "The Johto region is the setting of the second generation of Pokémon games, which includes Pokémon Gold, Silver, Crystal and their remakes, Pokémon HeartGold and SoulSilver. Again, based on an area of Japan, this game's geography is based upon the Kansai, Tokai and eastern Shikoku areas of the country. The game setting draws upon the Kansai region's abundance of temples, the architectural design of the Kansai region and its geographical sights, such as Mount Fuji and the Naruto whirlpools."
                    },
                    new Region
                    {
                        Name = "Hoenn",
                        Description = "The Hoenn region is the setting of the third generation of Pokémon games, Pokémon Ruby, Sapphire and Emerald, as well as their remakes Pokémon Omega Ruby and Alpha Sapphire. This time being based on the Japanese island of Kyushu; the real world and game region share an abundance of smaller islands around the main one and a subtropical climate. Like Sinnoh, this region is known to have a large range of various natural environments, such as rainforests and deserts."
                    },
                    new Region
                    {
                        Name = "Sinnoh",
                        Description = "The Sinnoh region is the setting of the fourth generation of Pokémon games, which encompasses the setting of Pokémon Diamond, Pearl and Platinum, as well as their remakes Pokémon Brilliant Diamond and Shining Pearl and Pokémon Legends: Arceus.It is based on the northernmost island of Japan, Hokkaidō. The region was meant to have a 'northern' feel, with some routes being entirely covered in snow."
                    },
                    new Region
                    {
                        Name = "Unova",
                        Description = "The Unova region is the setting of the fifth generation of Pokémon games, which encompasses the setting of Pokémon Black and White and their sequels Pokémon Black 2 and White 2. For the first time in the main series, the region was based on a region outside Japan, with Unova taking inspiration from the New York metropolitan area."
                    },
                    new Region
                    {
                        Name = "Kalos",
                        Description = "The Kalos region is the setting of the sixth generation of Pokémon games, which is where the games Pokémon X and Y take place. This region is inspired almost entirely by the northern half of Metropolitan France, with landmarks such as the Eiffel Tower and the Palace of Versailles having representations here, along with a French style of music and fashion. According to Junichi Masuda, the name 'Kalos' comes from the Ancient Greek word κάλλος, 'beauty'. The Kalos Pokémon League is based on the Notre-Dame de Paris due to its castle/cathedral-like exterior."
                    },
                    new Region
                    {
                        Name = "Alola",
                        Description = "The Alola region is the setting of the seventh generation of Pokémon games, Pokémon Sun, Moon, Ultra Sun and Ultra Moon. This region is based on Hawaii, marking the second time a main entry Pokémon game setting has been inspired by a U.S. state. The name itself is a play on aloha, the Hawaiian word for both 'hello' and 'goodbye'."
                    },
                    new Region
                    {
                        Name = "Galar",
                        Description = "The Galar region is the setting of the eighth generation of Pokémon games, which is where the games Pokémon Sword and Shield take place. This region is primarily inspired by Great Britain (mainly England and parts of Scotland), showcasing landmarks inspired by Big Ben and Hadrian's Wall. Two additional areas, The Isle of Armor and The Crown Tundra, are based on the Isle of Man and Scotland respectively. The Galar Region was also introduced in Pokémon Journeys."
                    }
                };

            var users = new List<User>
            {
                new User
                {
                     Username = "Nanuseski",
                     Email = "kristina.nanuseski.3.18@ict.edu.rs",
                     Password = "$2a$11$mwUqA6C.x/mPc.pkXAxWPeQCtim9fEp1HlPns/Z2WqCgHDEnzDRey", //kmeKaca56
                     Role    = roles.ElementAt(0),
                     Blacklisted = false,
                     NumberOfUsernameChanges = 0
                },

                new User
                {
                     Username = "Nanuki",
                     Email = "kristina.nanuseski@gmail.com",
                     Password = "$2a$11$mwUqA6C.x/mPc.pkXAxWPeQCtim9fEp1HlPns/Z2WqCgHDEnzDRey", //kmeKaca56
                     Role    = roles.ElementAt(1),
                     Blacklisted = false,
                     NumberOfUsernameChanges = 0
                }
            };

            var images = new List<Image>
            {
                new Image
                {
                    Path = "001.png",
                    Alt = "Bulbasaur"
                },
                new Image
                {
                    Path = "002.png",
                    Alt = "Ivysaur"
                },
                new Image
                {
                    Path = "003.png",
                    Alt = "Venosaur"
                }
            };

            
            var pokemon = new List<Pokemon>
            {
                new Pokemon
                {
                    Name        = "Venusaur",
                    Number      = 3,
                    Description =   "Venusaur, the final form of the Bulbasaur evolution. This Seed Pokémon soaks up the sun's rays as a source of energy.",
                    Image       = images.ElementAt(2),
                    EvolutionId = null,
                    Region      = regions.ElementAt(0)
                },
            
            };

            pokemon.Add( new Pokemon
            {
                Name = "Ivysaur",
                Number = 2,
                Description = "The Seed Pokémon, Ivysaur, Bulbasaur's evolved form. The bulb on its back absorbs nourishment and blooms into a large flower.",
                Image = images.ElementAt(1),
                Region = regions.ElementAt(0)
            });

            pokemon.Add( new Pokemon
            {
                Name = "Bulbasaur",
                Number = 1,
                Image = images.ElementAt(0),
                Description = "Bulbasaur. It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal. Bulbasaur are extremely tough and very difficult to capture in the wild.",
                Region = regions.ElementAt(0)
            });


            var pokemonElementType = new List<PokemonElementType> { 
                new PokemonElementType
                {
                    Pokemon = pokemon.ElementAt(0),
                    ElementType =starterTypes.ElementAt(0)
                },new PokemonElementType
                {
                    Pokemon = pokemon.ElementAt(0),
                    ElementType =starterTypes.ElementAt(3)
                },new PokemonElementType
                {
                    Pokemon = pokemon.ElementAt(1),
                    ElementType =starterTypes.ElementAt(0)
                },new PokemonElementType
                {
                    Pokemon = pokemon.ElementAt(1),
                    ElementType =starterTypes.ElementAt(3)
                },new PokemonElementType
                {
                    Pokemon = pokemon.ElementAt(2),
                    ElementType =starterTypes.ElementAt(0)
                },new PokemonElementType
                {
                    Pokemon = pokemon.ElementAt(2),
                    ElementType =starterTypes.ElementAt(3)
                }
            };

            var pokemonTrener = new List<PokemonTrainer> {
                new PokemonTrainer
                {
                    Pokemon = pokemon.ElementAt(2),
                    Atk = 3,
                    Def = 3,
                    Cp = 10000,
                    Shiny = false,
                    Favorite = false,
                    Trainer = users.ElementAt(1)
                },new PokemonTrainer
                {
                    Pokemon = pokemon.ElementAt(2),
                    Atk = 33,
                    Def = 33,
                    Cp = 3300,
                    Shiny = false,
                    Favorite = false,
                    Trainer = users.ElementAt(1)
                }
            };

            var pokedex = new List<Pokedex> {
                new Pokedex {
                    Trainer = users.ElementAt(1),
                    Pokemon = pokemon.ElementAt(2),
                    AmountCaught = 2,
                    AmountCaughtShiny = 0
                }
            };


            context.Images.AddRange(images);
            context.RolePermissions.AddRange(rolePermissions);
            context.ElementTypes.AddRange(starterTypes);
            context.Regions.AddRange(regions);
            context.Users.AddRange(users);
            context.Pokemons.AddRange(pokemon);
            context.PokemonElementTypes.AddRange(pokemonElementType);
            context.PokemonTrainers.AddRange(pokemonTrener);
            context.Pokedexs.AddRange(pokedex);

            context.SaveChanges();

            //return Ok("Added");
            return StatusCode(201);
        }

    }
}
