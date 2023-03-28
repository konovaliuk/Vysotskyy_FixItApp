namespace FixItApp.Infrastructure.DataTransferObjects;

public class ApplicationExtendedDTO : ApplicationDTO
{
    public decimal? Price { get; set; }

    public string? Status { get; set; }
}