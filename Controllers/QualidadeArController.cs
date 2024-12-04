using Microsoft.AspNetCore.Mvc;
using WebAppCap7.Models;
using System.Collections.Generic;

namespace WebAppCap7.Controllers
{
    public class QualidadeArController : Controller
    {
        private List<QualidadeArModel> _qualidades;

        public QualidadeArController()
        {
            _qualidades = GetQualidadeArList();
        }

        public IActionResult Index()
        {
            return View(_qualidades);
        }

        public static List<QualidadeArModel> GetQualidadeArList()
        {
            var qualidadeArList = new List<QualidadeArModel>();

            for (int i = 0; i <= 5; i++)
            {
                var qualidadeAr = new QualidadeArModel
                {
                    Id = i,
                    IdEstacao = 100 + i,
                    DataHora = DateTime.Now.AddHours(-5),
                    NivelPm25 = 45.1 + i,
                    NivelPm10 = 90.5 + i,
                    ConfigAlertasIdConfiguracao = 1000 + i
                };

                qualidadeArList.Add(qualidadeAr);
            }

            return qualidadeArList;
        }
    }
}
