using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Soccer_Stats {

    public class  RootObject{
        public Player[] Player { get; set; }
    }

    public class Player {
        [JsonProperty ("assists")]
        public long Assists { get; set; }

        [JsonProperty ("big_chances_created")]
        public long BigChancesCreated { get; set; }

        [JsonProperty ("blocks")]
        public long Blocks { get; set; }

        [JsonProperty ("chance_of_playing_next_round")]
        public long? ChanceOfPlayingNextRound { get; set; }

        [JsonProperty ("chance_of_playing_this_round")]
        public long? ChanceOfPlayingThisRound { get; set; }

        [JsonProperty ("clean_sheets")]
        public long CleanSheets { get; set; }

        [JsonProperty ("clearances")]
        public long Clearances { get; set; }

        [JsonProperty ("code")]
        public long Code { get; set; }

        [JsonProperty ("cost_change_event")]
        public long CostChangeEvent { get; set; }

        [JsonProperty ("cost_change_event_fall")]
        public long CostChangeEventFall { get; set; }

        [JsonProperty ("cost_change_start")]
        public long CostChangeStart { get; set; }

        [JsonProperty ("cost_change_start_fall")]
        public long CostChangeStartFall { get; set; }

        [JsonProperty ("crosses")]
        public long Crosses { get; set; }

        [JsonProperty ("dreamteam_count")]
        public long DreamteamCount { get; set; }

        [JsonProperty ("element_type")]
        public long ElementType { get; set; }

        [JsonProperty ("ep_next")]
        public string EpNext { get; set; }

        [JsonProperty ("ep_this")]
        public string EpThis { get; set; }

        [JsonProperty ("errors_leading_to_goal")]
        public long ErrorsLeadingToGoal { get; set; }

        [JsonProperty ("event_points")]
        public long EventPoints { get; set; }

        [JsonProperty ("first_name")]
        public string FirstName { get; set; }

        [JsonProperty ("form")]
        public string Form { get; set; }

        [JsonProperty ("goals_conceded")]
        public long GoalsConceded { get; set; }

        [JsonProperty ("goals_scored")]
        public long GoalsScored { get; set; }

        [JsonProperty ("id")]
        public long Id { get; set; }

        [JsonProperty ("in_dreamteam")]
        public bool InDreamteam { get; set; }

        [JsonProperty ("interceptions")]
        public long Interceptions { get; set; }

        [JsonProperty ("key_passes")]
        public long KeyPasses { get; set; }

        [JsonProperty ("loaned_in")]
        public long LoanedIn { get; set; }

        [JsonProperty ("loaned_out")]
        public long LoanedOut { get; set; }

        [JsonProperty ("loans_in")]
        public long LoansIn { get; set; }

        [JsonProperty ("loans_out")]
        public long LoansOut { get; set; }

        [JsonProperty ("minutes")]
        public long Minutes { get; set; }

        [JsonProperty ("news")]
        public string News { get; set; }

        [JsonProperty ("now_cost")]
        public long NowCost { get; set; }

        [JsonProperty ("own_goal_earned")]
        public long OwnGoalEarned { get; set; }

        [JsonProperty ("own_goals")]
        public long OwnGoals { get; set; }

        [JsonProperty ("pass_completion")]
        public long PassCompletion { get; set; }

        [JsonProperty ("penalties_conceded")]
        public long PenaltiesConceded { get; set; }

        [JsonProperty ("penalties_earned")]
        public long PenaltiesEarned { get; set; }

        [JsonProperty ("penalties_missed")]
        public long PenaltiesMissed { get; set; }

        [JsonProperty ("penalties_saved")]
        public long PenaltiesSaved { get; set; }

        [JsonProperty ("photo")]
        public Uri Photo { get; set; }

        [JsonProperty ("points_per_game")]
        public string PointsPerGame { get; set; }

        [JsonProperty ("position")]
        public string Position { get; set; }

        [JsonProperty ("recoveries")]
        public long Recoveries { get; set; }

        [JsonProperty ("red_cards")]
        public long RedCards { get; set; }

        [JsonProperty ("saves")]
        public long Saves { get; set; }

        [JsonProperty ("second_name")]
        public string SecondName { get; set; }

        [JsonProperty ("selected_by_percent")]
        public string SelectedByPercent { get; set; }

        [JsonProperty ("shots")]
        public long Shots { get; set; }

        [JsonProperty ("special")]
        public bool Special { get; set; }

        [JsonProperty ("status")]
        public string Status { get; set; }

        [JsonProperty ("tackles")]
        public long Tackles { get; set; }

        [JsonProperty ("team")]
        public long Team { get; set; }

        [JsonProperty ("team_name")]
        public string Team_Name { get; set; }

        [JsonProperty ("total_points")]
        public long TotalPoints { get; set; }

        [JsonProperty ("transfers_in")]
        public long TransfersIn { get; set; }

        [JsonProperty ("transfers_in_event")]
        public long TransfersInEvent { get; set; }

        [JsonProperty ("transfers_out")]
        public long TransfersOut { get; set; }

        [JsonProperty ("transfers_out_event")]
        public long TransfersOutEvent { get; set; }

        [JsonProperty ("value_form")]
        public string ValueForm { get; set; }

        [JsonProperty ("value_season")]
        public string ValueSeason { get; set; }

        [JsonProperty ("was_fouled")]
        public long WasFouled { get; set; }

        [JsonProperty ("web_name")]
        public string WebName { get; set; }

        [JsonProperty ("yellow_cards")]
        public long YellowCards { get; set; }
    }    
}