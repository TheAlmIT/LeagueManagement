using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LMEntities.Common;

namespace LMEntities.Models
{
    public partial class Schedule : Entity
    {
        public Schedule()
        {
            this.MatchResults = new List<MatchResult>();
        }

        public int Id { get; set; }
        [Required]
        [DisplayName("Season Name")]
        public int SeasonId { get; set; }
        [DisplayName("Year")]
        public int? YearId { get; set; }
        [Required]
        [DisplayName("Home Team")]
        public int HomeTeamId { get; set; }
        [Required]
        [DisplayName("Visitor Team")]
        public int VisitorTeamId { get; set; }
        [Required]
        [DisplayName("Umpire Name")]
        public Nullable<int> UmpireId { get; set; }
        [Required]
        [DisplayName("Ground Name")]
        public Nullable<int> GroundId { get; set; }
          
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        [DateRange]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ScheduleDate { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModfiedBy { get; set; }
        public virtual ICollection<MatchResult> MatchResults { get; set; }
        public virtual Season Season { get; set; }
        public virtual Year Year { get; set; }

        public virtual Ground Ground { get; set; }


        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }

        public virtual User Umpire { get; set; }

    }
}
