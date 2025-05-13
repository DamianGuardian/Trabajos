using System;

namespace TrainerApi.Models;

public class Trainer{

    public string Id { get; set; }
    public string Name { get; set; }
    public string Age { get; set; }

    public DateTime Birthdate { get; set; }
    public List<Medals> Medals { get; set; }
    public DateTime CreatedAt { get; set; }
}

    public class Medals{
        public string Region { get; set; }

        public MedalsType Type { get; set; }   
    }
    public enum MedalsType{
        Unknow = 0,
        Gold = 1,
        Silver = 2,
        Bronze = 3
    }
