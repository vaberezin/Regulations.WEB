using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Regulations.WEB.Models;
using AutoMapper;
using Regulations.BLL.DTO;
using Regulations.BLL.Infrastructure;
using Regulations.BLL.Interfaces;


namespace Regulations.WEB.Controllers
{
    public class HomeController : Controller
    {
        //regulationService ctor injection:
        private readonly IRegulationService regulationService;
        public HomeController(IRegulationService regServ)
        {
            regulationService = regServ;
        }
        //end of injection

        //create /home/index method:

        public async Task<IActionResult> Index()
        {
            IEnumerable<RegulationDTO> regListDTOs = regulationService.GetRegulations(); //add async version for this method in service???
            //map dto-model onto view-model (otkuda => kuda) -> takoe napravlenie.
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RegulationDTO, RegulationViewModel>()).CreateMapper();
            var regulations = mapper.Map<IEnumerable<RegulationDTO>, List<RegulationViewModel>>(regListDTOs).ToList();
            return View(regulations);
        }


    }
}
