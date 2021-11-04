using System.Collections.Generic;

namespace GoTW
{
    public class CommanderSkillDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string ClassType {get;set; }
        public IEnumerable<SkillDTO> Skills { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }
    }
}
