using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SastoTech.Data;
using SastoTech.Models;

namespace SastoTech.Pages;

public class Mobile : PageModel
{
    private readonly AppDbContext _context;

    public Mobile(AppDbContext context)
    {
        _context = context;
    }

    public IList<Mobiles> MobilesList { get; set; } = default!;

    public List<string> BrandList { get; set; } = new();
    public List<string> CategoryList { get; set; } = new();
    public List<string> ProcessorList { get; set; } = new();
    public List<string> ScreenSizeList { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Brand { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Category { get; set; }

    [BindProperty(SupportsGet = true)]
    public double? MinPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public double? MaxPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Processor { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? ScreenSize { get; set; }

    public async Task OnGetAsync()
    {
        BrandList = await _context.Mobiles.Select(x => x.Brand).Distinct().OrderBy(x => x).ToListAsync();
        CategoryList = await _context.Mobiles.Select(x => x.Category).Distinct().OrderBy(x => x).ToListAsync();
        ProcessorList = await _context.Mobiles.Select(x => x.Processor).Distinct().OrderBy(x => x).ToListAsync();
        ScreenSizeList = await _context.Mobiles.Select(x => x.ScreenSize).Distinct().OrderBy(x => x).ToListAsync();

        var query = _context.Mobiles.AsQueryable();

        // Show only available products
        query = query.Where(x => x.IsAvailable);

        if (!string.IsNullOrEmpty(SearchString))
        {
            query = query.Where(s => s.Name.Contains(SearchString) || s.Description.Contains(SearchString));
        }

        if (!string.IsNullOrEmpty(Brand))
        {
            query = query.Where(x => x.Brand == Brand);
        }

        if (!string.IsNullOrEmpty(Category))
        {
            query = query.Where(x => x.Category == Category);
        }

        if (MinPrice.HasValue)
        {
            query = query.Where(x => x.ActualPrice >= MinPrice.Value);
        }

        if (MaxPrice.HasValue)
        {
            query = query.Where(x => x.ActualPrice <= MaxPrice.Value);
        }

        if (!string.IsNullOrEmpty(Processor))
        {
            query = query.Where(x => x.Processor.Contains(Processor));
        }

        if (!string.IsNullOrEmpty(ScreenSize))
        {
            query = query.Where(x => x.ScreenSize.Contains(ScreenSize));
        }

        MobilesList = await query.ToListAsync();
    }
}