using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestAPIKinopoisk;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
   

    public class KinopoiskRoot
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public object Name { get; set; }
        
        
        /* остальные поля включать с осторожностью из за их реализации возникают ошибки
         
        [JsonPropertyName("externalId")]
        public ExternalId ExternalId { get; set; }

        [JsonPropertyName("alternativeName")]
        public string AlternativeName { get; set; }

        [JsonPropertyName("enName")]
        public object EnName { get; set; }

        [JsonPropertyName("names")]
        public List<object> Names { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("typeNumber")]
        public int TypeNumber { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("description")]
        public object Description { get; set; }

        [JsonPropertyName("shortDescription")]
        public object ShortDescription { get; set; }

        [JsonPropertyName("slogan")]
        public object Slogan { get; set; }

        [JsonPropertyName("status")]
        public object Status { get; set; }

        [JsonPropertyName("rating")]
        public Rating Rating { get; set; }

        [JsonPropertyName("votes")]
        public Votes Votes { get; set; }

        [JsonPropertyName("movieLength")]
        public object MovieLength { get; set; }

        [JsonPropertyName("totalSeriesLength")]
        public object TotalSeriesLength { get; set; }

        [JsonPropertyName("seriesLength")]
        public object SeriesLength { get; set; }

        [JsonPropertyName("ratingMpaa")]
        public object RatingMpaa { get; set; }

        [JsonPropertyName("ageRating")]
        public object AgeRating { get; set; }

        [JsonPropertyName("poster")]
        public Poster Poster { get; set; }

        [JsonPropertyName("backdrop")]
        public Backdrop Backdrop { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }

        [JsonPropertyName("countries")]
        public List<Country> Countries { get; set; }

        [JsonPropertyName("budget")]
        public Budget Budget { get; set; }

        [JsonPropertyName("fees")]
        public Fees Fees { get; set; }

        [JsonPropertyName("premiere")]
        public Premiere Premiere { get; set; }

        [JsonPropertyName("ticketsOnSale")]
        public bool TicketsOnSale { get; set; }

        [JsonPropertyName("sequelsAndPrequels")]
        public List<object> SequelsAndPrequels { get; set; }

        [JsonPropertyName("watchability")]
        public Watchability Watchability { get; set; }

        [JsonPropertyName("top10")]
        public object Top10 { get; set; }

        [JsonPropertyName("top250")]
        public object Top250 { get; set; }

        [JsonPropertyName("isSeries")]
        public bool IsSeries { get; set; }

        [JsonPropertyName("audience")]
        public List<object> Audience { get; set; }

        [JsonPropertyName("deletedAt")]
        public object DeletedAt { get; set; }

        [JsonPropertyName("facts")]
        public List<object> Facts { get; set; }

        [JsonPropertyName("persons")]
        public List<Person> Persons { get; set; }

        [JsonPropertyName("spokenLanguages")]
        public List<object> SpokenLanguages { get; set; }

        [JsonPropertyName("seasonsInfo")]
        public List<object> SeasonsInfo { get; set; }

        [JsonPropertyName("collections")]
        public List<object> Collections { get; set; }

        [JsonPropertyName("productionCompanies")]
        public List<object> ProductionCompanies { get; set; }

        [JsonPropertyName("similarMovies")]
        public List<object> SimilarMovies { get; set; }

        [JsonPropertyName("releaseYears")]
        public List<object> ReleaseYears { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("networks")]
        public object Networks { get; set; }*/
    }






