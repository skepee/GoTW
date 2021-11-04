using System.ComponentModel.DataAnnotations;

namespace GoTW.API.Context
{
    public class CommanderSkill
    {
        [Key]
        public int CommanderId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ClassType { get; set; }
        public int? FigthingId { get; set; }
        public string Fighting { get; set; }
        public int? ExpeditionId { get; set; }
        public string Expedition { get; set; }
        public int? TrainingGroundId { get; set; }
        public string TrainingGround { get; set; }
        public int? StrategicSkillId { get; set; }
        public string StrategicSkill { get; set; }
        public int? WeirwoodId { get; set; }
        public string Weirwood { get; set; }
        public int? AwakeningId { get; set; }
        public string Awakening { get; set; }
        public string Skills { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }
    }
}
