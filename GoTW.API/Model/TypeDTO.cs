using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoTW.API.Model
{
    public enum CommanderType
    {
        Bowman,
        Cavalry,
        Infantry,
        Spearman
    }

    public class TypeDTO
    {
        public string Name { get; set; }
        public string Ico { get; set; }
    }
}
