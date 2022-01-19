using GoTW.API.Context;
using GoTW.API.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoTW.API.Controllers
{
    [ApiController]
    public class CommanderController : Controller
    {
        private readonly ILogger<CommanderController> _logger;
        private readonly CommanderContext _commanderContext;

        public CommanderController(ILogger<CommanderController> logger, CommanderContext commanderContext)
        {
            _logger = logger;
            _commanderContext = commanderContext;
        }


        [EnableCors]
        [HttpGet("api/Commanders/{skill?}")]
        public async Task<IActionResult> CommanderSkill(string skill)
        {
            Uri imgUri = new(string.Concat(Request.Scheme.ToString(), "://", Request.Host.ToString()));
            string IcoPath = string.Concat(imgUri.AbsoluteUri, "/Images/Types/");
            string CommanderPath = string.Concat(imgUri.AbsoluteUri, "/Images/Commanders/");

            IEnumerable<CommanderSkill> res = new List<CommanderSkill>();
            List<CommanderSkillDTO> commandersDTO = new();           

            await Task.Run(() =>
            {
            _logger.LogInformation("Starting new request");
            res = _commanderContext.CommanderSkill.FromSqlRaw<CommanderSkill>("Execute CommanderSkills").ToList();
                
            if (res != null)
            {
                if (!string.IsNullOrEmpty(skill))
                {
                        res=res.Where(x => x.Skills.Contains(skill.ToLower()));
                }

                foreach (var item in res)
                {
                    //_logger.LogInformation($"imgUri:{imgUri}");
                    //_logger.LogInformation($"imgpath:{imgPath}");

                    commandersDTO.Add(new CommanderSkillDTO()
                    {
                        Name = item.Name,
                        Image= string.Concat(CommanderPath, item.Name.Replace(" ", "").Replace("'", ""), ".jpg"),
                        Type = item.Type,
                        ClassType = item.ClassType,
                        Skills = Helper.AddSkills(item),
                        Source = item.Source,
                        Notes = item.Notes
                    });
                }
                _logger.LogInformation("Ending request");
            }           
            });
            return base.Ok(new CommandersDTO()
            { 
                CommanderSkills= commandersDTO,
                CommanderTypes= new List<TypeDTO>() {
                    new TypeDTO(){ Name=CommanderType.Bowman.ToString(), Ico=string.Concat(IcoPath, CommanderType.Bowman.ToString() + ".jpg") },
                    new TypeDTO(){ Name=CommanderType.Cavalry.ToString(), Ico=string.Concat(IcoPath, CommanderType.Cavalry.ToString() + ".jpg") },
                    new TypeDTO(){ Name=CommanderType.Spearman.ToString(), Ico=string.Concat(IcoPath, CommanderType.Spearman.ToString() + ".jpg") },
                    new TypeDTO(){ Name=CommanderType.Infantry.ToString(), Ico=string.Concat(IcoPath, CommanderType.Infantry.ToString() + ".jpg") }
            }
        });
        }

    }
}
