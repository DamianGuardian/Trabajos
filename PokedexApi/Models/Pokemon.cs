using System.Collections;
using PokedexApi.Dtos;

namespace PokemonApi.Models;
   

    public class Pokemon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }

        // New constructor
        public Pokemon(Guid id, string name, string type, int level, int attack, int defense, int speed)
        {
            Id = id;
            Name = name;
            Type = type;
            Level = level;
            Attack = attack;
            Defense = defense;
            Speed = speed;
        }

        // Existing constructors (if any)
    }
