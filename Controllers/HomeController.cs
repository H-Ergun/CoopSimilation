using CoopSimilation.Models;
using CoopSimilation.Services;
using Microsoft.AspNetCore.Mvc;


namespace CoopSimilation.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int count)
        {
            //dosya okumak için ayarlar yapılıyor
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

            //dosyadan gerekli ayarlar sınıflara atanıyor
            var animalConfigArray = configuration.GetSection("Animals").Get<List<ConfigAnimal>>();

            var rabbitConfig = animalConfigArray.First(x => x.Name == "Rabbit");

            if (rabbitConfig is not null)
            {
                //similasyon 

                Factory<Rabbit> factory = new(rabbitConfig);

                var similation = new Similation<Rabbit>(rabbitConfig, factory)
                {
                    LoopCount = count
                };

                similation.Run();

                //rapor oluşturuluyor

                Report report = Report.CreateReport(similation, count);

                similation = null;

                return View(report);

            }

            return View();


        }



        public IActionResult MyTest()
        {


            return View();
        }



    }
}