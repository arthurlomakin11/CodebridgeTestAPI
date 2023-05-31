using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CodebridgeTestAPI;

[Index(nameof(Name), IsUnique=true)]
public class Dog
{
    [Key]
    [JsonIgnore]
    public int Id { get; set; }

    
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; }

    
    [Required(AllowEmptyStrings = false)] 
    public string Color { get; set; }


    [Range(1, int.MaxValue)]
    [JsonPropertyName("tail_length")]
    public int TailLength { get; set; }
    
    
    [Range(1, int.MaxValue)] 
    public int Weight { get; set; }
}