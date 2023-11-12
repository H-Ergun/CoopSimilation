using CoopSimilation.Enums;

namespace CoopSimilation.Models
{
    public interface IAnimal
    {

        /// <summary>
        /// cinsiyeti /init variable
        /// </summary>

        public Gender Gender { get; set; }


        /// <summary>
        /// doğum zamanı /init var
        /// </summary>

        public int DateCreated { get; set; }


        /// <summary>
        /// yaşam süresi /init var
        /// </summary>
        public int LifeTime { get; set; }



        /// <summary>
        /// Gebelik Süresi ay /init var
        /// </summary>

        public int Gestation { get; set; }

        /// <summary>
        /// Ergenlik yaşı /init var
        /// </summary>

        public int PubertyAge { get; set; }

        /// <summary>
        /// Son Gebe Kaldığı ay /runtime var 
        /// </summary>

        public int LastReproductionDate { get; set; }


        /// <summary>
        /// tekrardan gebe kalma süresi  /runtime var
        /// </summary>

        public int ReproductionReadyTime { get; set; }

        /// <summary>
        /// tek yavrulamadaki yavru sayısı /runtime
        /// </summary>
        public int OffspringPerBirth { get; set;}


        /// <summary>
        /// şuan hamilemi
        /// </summary>
        public bool IsReproduction { get; set; }


        public int ChildCount { get; set; }
        



    }
}
