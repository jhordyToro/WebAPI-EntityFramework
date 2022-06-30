//Thsi code line is for import the DataAnnotations of EntityFramework for can expesificated better our table of data
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace minimalAPIef.Models
{
    public class Category
    {
        // [Key] // => LLave foranea: esta es una manera de utilizar los DataAnnotations
        public Guid CategoryId {get; set;}

        // [Required] // => field required:
        // [MaxLength(150)] // =>  Max of Caracters
        public string Name {get; set;}

        public string? Description {get; set;}

        public int weight {get;set;}

        [JsonIgnore]
        [ValidateNever]
        public virtual ICollection<Task> Tasks {get;set;}
    }
}