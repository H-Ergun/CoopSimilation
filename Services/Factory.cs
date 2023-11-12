using CoopSimilation.Enums;
using CoopSimilation.Extensions;
using CoopSimilation.Models;
using System.Reflection;

namespace CoopSimilation.Services
{
    public class Factory<T> where T : IAnimal, new()
    {
        static Random random = new();

        ConfigAnimal configAnimal;
        public Factory(ConfigAnimal configAnimal)
        {
            this.configAnimal = configAnimal;
        }

        /// <summary>
        /// random gender create animal
        /// </summary>
        /// <param name="dateCreated"></param>
        /// <returns></returns>
        public T CreateAnimal(int dateCreated)
        {   
           
            int gender = random.Next(0, 2);

            int lifeTime = random.Next(configAnimal.LifeTime);

            int gestation = random.Next(configAnimal.Gestation);

            int pubertyAge = random.Next(configAnimal.PubertyAge);

            return new T() {  Gender = (Gender)gender, DateCreated = dateCreated, LifeTime = lifeTime, Gestation = gestation, PubertyAge = pubertyAge, IsReproduction = false };
        }


        /// <summary>
        /// create with gender animal
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public T CreateAnimal(Gender gender)
        {
            int lifeTime = random.Next(configAnimal.LifeTime);

            int gestation = random.Next(configAnimal.Gestation);

            int pubertyAge = random.Next(configAnimal.PubertyAge);

            return new T() {  Gender = gender, DateCreated = 0, LifeTime = lifeTime, Gestation = gestation, PubertyAge = pubertyAge, IsReproduction = false };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateCreated"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public T CreateAnimal(int dateCreated, Gender gender)
        {

            int lifeTime = random.Next(configAnimal.LifeTime);

            int gestation = random.Next(configAnimal.Gestation);

            int pubertyAge = random.Next(configAnimal.PubertyAge);

            return new T() {Gender = gender, DateCreated = dateCreated, LifeTime = lifeTime, Gestation = gestation, PubertyAge = pubertyAge, IsReproduction = false };
        }



    }
}
