using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoTW.API.Model
{
    public class CommandersDTO
    {
        public IEnumerable<CommanderSkillDTO> CommanderSkills { get; set; }
        public IEnumerable<TypeDTO> CommanderTypes { get; set; }
    }
}
