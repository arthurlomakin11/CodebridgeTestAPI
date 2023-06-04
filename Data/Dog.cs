using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace CodebridgeTestAPI;

[Index(nameof(Name), IsUnique=true)]
public class Dog
{
    [Key, JsonIgnore, BindNever]
    public int Id { get; set; }

    
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; }

    
    [Required(AllowEmptyStrings = false)]
    public string Color { get; set; }


    [Required, Range(1, int.MaxValue)]
    [JsonPropertyName("tail_length")]
    public int TailLength { get; set; }
    
    
    [Required, Range(1, int.MaxValue)] 
    public int Weight { get; set; }
}