using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApp.Model
{
    public class DetailedActivity
    {
        ///<summary>
        /// The unique identifier of the activity
        ///</summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        ///<summary>
        /// The identifier provided at upload time
        ///</summary>
        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        ///<summary>
        /// The identifier of the upload that resulted in this activity
        ///</summary>
        [JsonPropertyName("upload_id")]
        public long UploadId { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-MetaAthlete">MetaAthlete</a>.
        ///</summary>
        [JsonPropertyName("athlete")]
        public MetaAthlete Athlete { get; set; }

        ///<summary>
        /// The name of the activity
        ///</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        ///<summary>
        /// The activity&#39;s distance, in meters
        ///</summary>
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        ///<summary>
        /// The activity&#39;s moving time, in seconds
        ///</summary>
        [JsonPropertyName("moving_time")]
        public int MovingTime { get; set; }

        ///<summary>
        /// The activity&#39;s elapsed time, in seconds
        ///</summary>
        [JsonPropertyName("elapsed_time")]
        public int ElapsedTime { get; set; }

        ///<summary>
        /// The activity&#39;s total elevation gain.
        ///</summary>
        [JsonPropertyName("total_elevation_gain")]
        public float TotalElevationGain { get; set; }

        ///<summary>
        /// The activity&#39;s highest elevation, in meters
        ///</summary>
        [JsonPropertyName("elev_high")]
        public float ElevHigh { get; set; }

        ///<summary>
        /// The activity&#39;s lowest elevation, in meters
        ///</summary>
        [JsonPropertyName("elev_low")]
        public float ElevLow { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-ActivityType">ActivityType</a>.
        ///</summary>
        [JsonPropertyName("type")]
        public ActivityType Type { get; set; }

        ///<summary>
        /// The time at which the activity was started.
        ///</summary>
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        ///<summary>
        /// The time at which the activity was started in the local timezone.
        ///</summary>
        [JsonPropertyName("start_date_local")]
        public DateTime StartDateLocal { get; set; }

        ///<summary>
        /// The timezone of the activity
        ///</summary>
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-LatLng">LatLng</a>.
        ///</summary>
        [JsonPropertyName("start_latlng")]
        public double[] StartLatlng { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-LatLng">LatLng</a>.
        ///</summary>
        [JsonPropertyName("end_latlng")]
        public double[] EndLatlng { get; set; }

        ///<summary>
        /// The number of achievements gained during this activity
        ///</summary>
        [JsonPropertyName("achievement_count")]
        public int AchievementCount { get; set; }

        ///<summary>
        /// The number of kudos given for this activity
        ///</summary>
        [JsonPropertyName("kudos_count")]
        public int KudosCount { get; set; }

        ///<summary>
        /// The number of comments for this activity
        ///</summary>
        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }

        ///<summary>
        /// The number of athletes for taking part in a group activity
        ///</summary>
        [JsonPropertyName("athlete_count")]
        public int AthleteCount { get; set; }

        ///<summary>
        /// The number of Instagram photos for this activity
        ///</summary>
        [JsonPropertyName("photo_count")]
        public int PhotoCount { get; set; }

        ///<summary>
        /// The number of Instagram and Strava photos for this activity
        ///</summary>
        [JsonPropertyName("total_photo_count")]
        public int TotalPhotoCount { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-PolylineMap">PolylineMap</a>.
        ///</summary>
        [JsonPropertyName("map")]
        public PolylineMap Map { get; set; }

        ///<summary>
        /// Whether this activity was recorded on a training machine
        ///</summary>
        [JsonPropertyName("trainer")]
        public bool Trainer { get; set; }

        ///<summary>
        /// Whether this activity is a commute
        ///</summary>
        [JsonPropertyName("commute")]
        public bool Commute { get; set; }

        ///<summary>
        /// Whether this activity was created manually
        ///</summary>
        [JsonPropertyName("manual")]
        public bool Manual { get; set; }

        ///<summary>
        /// Whether this activity is private
        ///</summary>
        [JsonPropertyName("private")]
        public bool Private { get; set; }

        ///<summary>
        /// Whether this activity is flagged
        ///</summary>
        [JsonPropertyName("flagged")]
        public bool Flagged { get; set; }

        ///<summary>
        /// The activity&#39;s workout type
        ///</summary>
        [JsonPropertyName("workout_type")]
        public int WorkoutType { get; set; }

        ///<summary>
        /// The unique identifier of the upload in string format
        ///</summary>
        [JsonPropertyName("upload_id_str")]
        public string UploadIdStr { get; set; }

        ///<summary>
        /// The activity&#39;s average speed, in meters per second
        ///</summary>
        [JsonPropertyName("average_speed")]
        public float AverageSpeed { get; set; }

        ///<summary>
        /// The activity&#39;s max speed, in meters per second
        ///</summary>
        [JsonPropertyName("max_speed")]
        public float MaxSpeed { get; set; }

        ///<summary>
        /// Whether the logged-in athlete has kudoed this activity
        ///</summary>
        [JsonPropertyName("has_kudoed")]
        public bool HasKudoed { get; set; }

        ///<summary>
        /// Whether the activity is muted
        ///</summary>
        [JsonPropertyName("hide_from_home")]
        public bool HideFromHome { get; set; }

        ///<summary>
        /// The id of the gear for the activity
        ///</summary>
        [JsonPropertyName("gear_id")]
        public string GearId { get; set; }

        ///<summary>
        /// The total work done in kilojoules during this activity. Rides only
        ///</summary>
        [JsonPropertyName("kilojoules")]
        public float Kilojoules { get; set; }

        ///<summary>
        /// Average power output in watts during this activity. Rides only
        ///</summary>
        [JsonPropertyName("average_watts")]
        public float AverageWatts { get; set; }

        ///<summary>
        /// Whether the watts are from a power meter, false if estimated
        ///</summary>
        [JsonPropertyName("device_watts")]
        public bool DeviceWatts { get; set; }

        ///<summary>
        /// Rides with power meter data only
        ///</summary>
        [JsonPropertyName("max_watts")]
        public int MaxWatts { get; set; }

        ///<summary>
        /// Similar to Normalized Power. Rides with power meter data only
        ///</summary>
        [JsonPropertyName("weighted_average_watts")]
        public int WeightedAverageWatts { get; set; }

        ///<summary>
        /// The description of the activity
        ///</summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-PhotosSummary">PhotosSummary</a>.
        ///</summary>
        [JsonPropertyName("photos")]
        public PhotosSummary Photos { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-SummaryGear">SummaryGear</a>.
        ///</summary>
        [JsonPropertyName("gear")]
        public SummaryGear Gear { get; set; }

        ///<summary>
        /// The number of kilocalories consumed during this activity
        ///</summary>
        [JsonPropertyName("calories")]
        public float Calories { get; set; }

        ///<summary>
        /// A collection of <a href="#api-models-DetailedSegmentEffort">DetailedSegmentEffort</a> objects.
        ///</summary>
        [JsonPropertyName("segment_efforts")]
        public List<DetailedSegmentEffort> SegmentEfforts { get; set; }

        ///<summary>
        /// The name of the device used to record the activity
        ///</summary>
        [JsonPropertyName("device_name")]
        public string DeviceName { get; set; }

        ///<summary>
        /// The token used to embed a Strava activity
        ///</summary>
        [JsonPropertyName("embed_token")]
        public string EmbedToken { get; set; }

        ///<summary>
        /// The splits of this activity in metric units (for runs)
        ///</summary>
        [JsonPropertyName("splits_metric")]
        public Split SplitsMetric { get; set; }

        ///<summary>
        /// The splits of this activity in imperial units (for runs)
        ///</summary>
        [JsonPropertyName("splits_standard")]
        public Split SplitsStandard { get; set; }

        ///<summary>
        /// A collection of <a href="#api-models-DetailedSegmentEffort">DetailedSegmentEffort</a> objects.
        ///</summary>
        [JsonPropertyName("best_efforts")]
        public DetailedSegmentEffort BestEfforts { get; set; }

    }
}
