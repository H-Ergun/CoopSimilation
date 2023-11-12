using CoopSimilation.Enums;
using CoopSimilation.Services;

namespace CoopSimilation.Models
{
    public class Report
    {

        public int LoopCount { get; set; }

        public int Population { get; set; }

        public int PopulationMale { get; set; }

        public int PopulationFemale { get; set; }

        public int MaxAgeMale { get; set; }

        public int MaxAgeFemale { get; set; }

        public int DeathCount { get; set; }

        public int MaxPerBirth { get; set; } 



        public Report()
        {

        }


        public static Report CreateReport<T>(Similation<T> similation, int loopCount) where T : IAnimal, new()
        {

            return new Report()
            {
                LoopCount = loopCount,
                Population = similation.Animals.Count,
                PopulationMale = similation.Animals.Count(x => x.Gender == Gender.Male),
                PopulationFemale = similation.Animals.Count(x => x.Gender == Gender.Female),
                MaxAgeMale = loopCount - similation.Animals.Where(x => x.Gender == Gender.Male).Min(x => x.DateCreated),
                MaxAgeFemale = loopCount - similation.Animals.Where(x => x.Gender == Gender.Female).Min(x => x.DateCreated),
                DeathCount= similation.DeathCount,
                MaxPerBirth= similation.MaxPerBirth
            };

        }



    }
}
