using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class MatchResult
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int WinningTeamId { get; set; }
        public int LosingTeamId { get; set; }
        public int WinningTeamPoints { get; set; }
        public int LosingTeamPoints { get; set; }
        public Nullable<int> WinningTeamScore { get; set; }
        public Nullable<int> LosingTeamScore { get; set; }
        public Nullable<int> WinningTeamWkts { get; set; }
        public Nullable<int> LosingTeamWkts { get; set; }
        public Nullable<decimal> WinningTeamOvers { get; set; }
        public Nullable<decimal> LosingTeamOvers { get; set; }
        public string Summary { get; set; }
        public int MVPlayerId { get; set; }
        public int TossWinningTeamId { get; set; }
        public int FirstBattingTeamId { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual User User { get; set; }
        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual User User1 { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual TeamMember TeamMember { get; set; }
        public virtual Team Team2 { get; set; }
        public virtual Team Team3 { get; set; }
    }
}
