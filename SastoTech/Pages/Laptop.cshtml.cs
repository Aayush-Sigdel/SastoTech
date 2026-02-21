using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SastoTech.Data;
using SastoTech.Models;

namespace SastoTech.Pages;

public class Laptop : PageModel
{
    private readonly AppDbContext _context;

    public Laptop(AppDbContext context)
    {
        _context = context;
    }

    public IList<Laptops> LaptopsList { get; set; } = default!;
    
    public List<string> BrandList { get; set; } = new();
    public List<string> CategoryList { get; set; } = new();
    public List<string> CpuList { get; set; } = new();
    public List<string> GpuList { get; set; } = new();
    public List<string> ScreenSizeList { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Brand { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Category { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? MinPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? MaxPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Cpu { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Gpu { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? ScreenSize { get; set; }

    public async Task OnGetAsync()
    {
        BrandList = await _context.Laptops.Select(x => x.Brand).Distinct().OrderBy(x => x).ToListAsync();
        CategoryList = await _context.Laptops.Select(x => x.Category).Distinct().OrderBy(x => x).ToListAsync();
        CpuList = await _context.Laptops.Select(x => x.Cpu).Distinct().OrderBy(x => x).ToListAsync();
        GpuList = await _context.Laptops.Select(x => x.Gpu).Distinct().OrderBy(x => x).ToListAsync();
        ScreenSizeList = await _context.Laptops.Select(x => x.ScreenSize).Distinct().OrderBy(x => x).ToListAsync();

        var query = _context.Laptops.AsQueryable();

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

        if (!string.IsNullOrEmpty(Cpu))
        {
            query = query.Where(x => x.Cpu.Contains(Cpu));
        }

        if (!string.IsNullOrEmpty(Gpu))
        {
            query = query.Where(x => x.Gpu.Contains(Gpu));
        }

        if (!string.IsNullOrEmpty(ScreenSize))
        {
            query = query.Where(x => x.ScreenSize.Contains(ScreenSize));
        }

        LaptopsList = await query.ToListAsync();
    }
}