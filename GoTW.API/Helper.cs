using GoTW.API.Context;
using GoTW.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace GoTW.API
{
    public enum CommanderSkillType
    {
        Fighting,
        Expedition, 
        TrainingGround,
        StrategicSkill,
        Weirwood,
        Awakening
    }


public static class Helper
    {
        public static IEnumerable<SkillDTO> AddSkills(CommanderSkill item)
        {
            var res = new List<SkillDTO>();

            if (item.FigthingId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.Fighting.ToString(),
                    Id = (int)item.FigthingId,
                    Value = item.Fighting
                });

            if (item.ExpeditionId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.Expedition.ToString(),
                    Id = (int)item.ExpeditionId,
                    Value = item.Expedition
                });

            if (item.TrainingGroundId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.TrainingGround.ToString(),
                    Id = (int)item.TrainingGroundId,
                    Value = item.TrainingGround
                });

            if (item.StrategicSkillId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.StrategicSkill.ToString(),
                    Id = (int)item.StrategicSkillId,
                    Value = item.StrategicSkill
                });

            if (item.WeirwoodId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.Weirwood.ToString(),
                    Id = (int)item.WeirwoodId,
                    Value = item.Weirwood
                });

            if (item.AwakeningId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.Awakening.ToString(),
                    Id = (int)item.AwakeningId,
                    Value = item.Awakening
                });

            return res.AsEnumerable();
        }

    }
}
