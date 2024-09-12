using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHub.Domain.User.ValueObjects;

public class Address
{
    [Column("StreeName")]
    public string StreeName { get; set; }

    [Column("Number")]
    public int Number { get; set; }

    [Column("Floor")]
    public string? Floor { get; set; }

    [Column("Zipcode")]
    public string Zipcode { get; set; }

    [Column("City")]
    public string City { get; set; }

    [Column("Municipality")]
    public string Municipality { get; set; }

    [Column("Region")]
    public string Region { get; set; }

    [Column("Country")]
    public string Country { get; set; }

    [Column("CountryCode")]
    public string CountryCode { get; set; }
}
