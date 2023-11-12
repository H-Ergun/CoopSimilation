using CoopSimilation.Enums;
using CoopSimilation.Extensions;
using CoopSimilation.Models;

namespace CoopSimilation.Services
{
    public class Similation<T> where T : IAnimal, new()
    {
        public List<T> Animals = new();

        public int LoopCount { get; set; }        

        public int  DeathCount { get; set; } //Rapor

        public int MaxPerBirth { get; set; } //Rapor

        Factory<T> factory;

        ConfigAnimal configAnimal;

        static Random random = new Random();



        public Similation(ConfigAnimal configAnimal, Factory<T> factory)
        {
            this.configAnimal = configAnimal;

            this.factory = factory;
        }



        public void Run()
        {

            Animals.Add(factory.CreateAnimal(Gender.Female)); //erkek tavşan oluşturuldu

            Animals.Add(factory.CreateAnimal(Gender.Male)); //dişi tavşan oluşturuldu

            for (int i = 0; i < LoopCount; i++)
            {
                Gravedigger(i);
                Insemination(i);
                Obstetrician(i);
            }

        }



        /// <summary>
        /// Mezarcı ölen tavşanları listeden siler
        /// </summary>

        private void Gravedigger(int currenMonth)
        {            
            DeathCount += Animals.RemoveAll(x => (x.LifeTime + x.DateCreated - currenMonth) <= 0);
        }


        /// <summary>
        /// Tohumlama Yavrulamaya uygun tavşanlar tohumlanıyor
        /// </summary>
        /// <param name="currenMonth"></param>

        private void Insemination(int currenMonth)
        {
            Animals.Where(x =>
                                x.Gender == Gender.Female &&
                                !x.IsReproduction &&
                                (currenMonth - x.DateCreated) >= x.PubertyAge && //Ergenlik yaşı kontrol ediliyor                                                                
                                (currenMonth - (x.LastReproductionDate + x.Gestation + x.ReproductionReadyTime)) >= 0 //tekrardan gebe kalma süresini bitirmişmi
                                ).ToList().ForEach(y =>
                                                      {
                                                          
                                                          y.LastReproductionDate = currenMonth; //son gebe kalma tarihi set ediliyor
                                                          y.ReproductionReadyTime = random.Next(configAnimal.ReproductionReadyTime); //bu gebelikten sonra kaç ay gebe kalamayacağını set ediyor
                                                          y.OffspringPerBirth = random.Next(configAnimal.OffspringPerBirth); //doğumda kaç yavru olacağı set ediliyor
                                                          y.IsReproduction = true;   
                                                        

                                                      }
                                                    );
        }

        /// <summary>
        /// Doğum uzmanı gebelik süresi sona eren dişiler doğum yapmasını sağlar
        /// </summary>
        /// <param name="currenMonth"></param>
        private void Obstetrician(int currenMonth)
        {
            Animals.Where(x =>
                            x.Gender == Gender.Female &&
                            x.IsReproduction &&
                            (currenMonth - x.LastReproductionDate-x.Gestation) == 0  //suanki zaman -(son gebe  klama tarihi +  gebelik süresi )
                            ).ToList().ForEach(y =>
                                                    {

                                                        MaxPerBirth = MaxPerBirth < y.OffspringPerBirth ? y.OffspringPerBirth : MaxPerBirth;//Rapor için

                                                        y.ChildCount += y.OffspringPerBirth;

                                                        y.IsReproduction = false;                                                        

                                                        for (int i = 0; i < y.OffspringPerBirth; i++)
                                                        {   

                                                            Animals.Add(factory.CreateAnimal(currenMonth));
                                                        }


                                                    });

        }


    }
}
