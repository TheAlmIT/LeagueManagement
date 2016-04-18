using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LMEntities.Models.Mapping;
using Repository.Pattern.Ef6;
namespace LMEntities.Models
{
    public partial class SportsSiteContext : DataContext
    {
        static SportsSiteContext()
        {
            Database.SetInitializer<SportsSiteContext>(null);
        }

        public SportsSiteContext()
            : base("Name=SportsSiteContext")
        {
        }
        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserRoles> AspNetUsersRoles { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public IDbSet<CityStateZip> CityStateZips { get; set; }
        public IDbSet<Event> Events { get; set; }
        public IDbSet<EventAddress> EventAddresses { get; set; }
        public IDbSet<EventComment> EventComments { get; set; }
        public IDbSet<EventInvitee> EventInvitees { get; set; }
        public IDbSet<EventMedia> EventMedias { get; set; }
        public IDbSet<EventType> EventTypes { get; set; }
        public IDbSet<Facility> Facilities { get; set; }
        public IDbSet<FacilityBooking> FacilityBookings { get; set; }
        public IDbSet<FacilityBookingStatu> FacilityBookingStatus { get; set; }
        public IDbSet<FacilityBookingUnitType> FacilityBookingUnitTypes { get; set; }
        public IDbSet<FacilityCancellation> FacilityCancellations { get; set; }
        public IDbSet<Gender> Genders { get; set; }
        public IDbSet<League> Leagues { get; set; }
        public IDbSet<MatchResult> MatchResults { get; set; }
        public IDbSet<MediaComment> MediaComments { get; set; }
        public IDbSet<MediaType> MediaTypes { get; set; }
        public IDbSet<Notification> Notifications { get; set; }
        public IDbSet<NotificationStatu> NotificationStatus { get; set; }
        public IDbSet<NotificationType> NotificationTypes { get; set; }
        public IDbSet<Organization> Organizations { get; set; }
        public IDbSet<RSVPMaster> RSVPMasters { get; set; }
        public IDbSet<Schedule> Schedules { get; set; }

        public IDbSet<Ground> Grounds { get; set; }
        public IDbSet<Season> Seasons { get; set; }
        public IDbSet<SkillSpeciality> SkillSpecialities { get; set; }
        public IDbSet<sysdiagram> sysdiagrams { get; set; }
        public IDbSet<Team> Teams { get; set; }
        public IDbSet<TeamManagement> TeamManagements { get; set; }
        public IDbSet<TeamMember> TeamMembers { get; set; }
        public IDbSet<TeamTitle> TeamTitles { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserType> UserTypes { get; set; }
        public IDbSet<Year> Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.Add(new AspNetRoleMap());
            //modelBuilder.Configurations.Add(new AspNetUserRoleMap());

            modelBuilder.Configurations.Add(new GroundMap());
            modelBuilder.Configurations.Add(new CityStateZipMap());
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new EventAddressMap());
            modelBuilder.Configurations.Add(new EventCommentMap());
            modelBuilder.Configurations.Add(new EventInviteeMap());
            modelBuilder.Configurations.Add(new EventMediaMap());
            modelBuilder.Configurations.Add(new EventTypeMap());
            modelBuilder.Configurations.Add(new FacilityMap());
            modelBuilder.Configurations.Add(new FacilityBookingMap());
            modelBuilder.Configurations.Add(new FacilityBookingStatuMap());
            modelBuilder.Configurations.Add(new FacilityBookingUnitTypeMap());
            modelBuilder.Configurations.Add(new FacilityCancellationMap());
            modelBuilder.Configurations.Add(new GenderMap());
            modelBuilder.Configurations.Add(new LeagueMap());
            modelBuilder.Configurations.Add(new MatchResultMap());
            modelBuilder.Configurations.Add(new MediaCommentMap());
            modelBuilder.Configurations.Add(new MediaTypeMap());
            modelBuilder.Configurations.Add(new NotificationMap());
            modelBuilder.Configurations.Add(new NotificationStatuMap());
            modelBuilder.Configurations.Add(new NotificationTypeMap());
            modelBuilder.Configurations.Add(new OrganizationMap());
            modelBuilder.Configurations.Add(new RSVPMasterMap());
            modelBuilder.Configurations.Add(new ScheduleMap());
            modelBuilder.Configurations.Add(new SeasonMap());
            modelBuilder.Configurations.Add(new SkillSpecialityMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TeamMap());
            modelBuilder.Configurations.Add(new TeamManagementMap());
            modelBuilder.Configurations.Add(new TeamMemberMap());
            modelBuilder.Configurations.Add(new TeamTitleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserTypeMap());
            modelBuilder.Configurations.Add(new YearMap());
        }
    }
}
