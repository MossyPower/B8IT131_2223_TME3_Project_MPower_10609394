using Microsoft.EntityFrameworkCore;
namespace MvcRugby.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    //public List<TestList> TestLists { get; set; }
}
