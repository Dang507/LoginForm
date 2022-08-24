namespace Api.Models;
using System.ComponentModel;
using System.Text.Json.Serialization;

public class Customer

{
    
    public int Id { get; set; }
    
    public string Username { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public string Roles { get; set; }

    
}