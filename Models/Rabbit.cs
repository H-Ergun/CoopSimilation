using CoopSimilation.Enums;
using System.Reflection;

namespace CoopSimilation.Models
{
    public class Rabbit : IAnimal
    {
        public int DateCreated { get; set; }
        public int Gestation { get; set; }
        public int PubertyAge { get; set; }
        public int ReproductionReadyTime { get; set; }
        public Gender Gender { get; set; }
        public int LifeTime { get; set; }
        public int OffspringPerBirth { get; set; }
        public int LastReproductionDate { get; set; }
        public bool IsReproduction { get; set; }

        public int ChildCount { get; set; }

        
    }

}