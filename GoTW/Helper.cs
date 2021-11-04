using System.Collections.Generic;
using System.Linq;

namespace GoTW
{
    public static class Helper 
    {
        public static IEnumerable<CommanderIconDTO> CommanderSkillDetail(this IEnumerable<CommanderSkillDTO> commanders)
        {
            return commanders.Select(a =>
               new CommanderIconDTO()
               {
                   Name = a.Name,
                   Image = a.Image,
                   ClassType = a.ClassType,
                   Skill = a.Skills.FirstOrDefault()
               }).OrderByDescending(x => x.Skill.Value).ToList();
        }
    }
}
