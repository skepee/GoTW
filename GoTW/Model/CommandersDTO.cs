using System.Collections.Generic;

namespace GoTW
{
    public class CommandersDTO
    {
        public IEnumerable<CommanderSkillDTO> CommanderSkills { get; set; }
        public IEnumerable<TypeDTO> CommanderTypes { get; set; }
    }
}
