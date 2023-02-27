using Microsoft.AspNetCore.Mvc;
using RetailStoreWeb.Interfaces;
using RetailStoreWeb.Models;

namespace RetailStoreWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly ILogger<StoreController> _logger;

    private readonly IStoreRepository _StoreService;

    public StoreController(ILogger<StoreController> logger,IStoreRepository StoreService)
    {
        _logger = logger;
        _StoreService = StoreService;
    }

    [HttpGet(Name = "GetStores")]
    public IEnumerable<Store> Get()
    {
        return  _StoreService.Stores;
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Store>> Get(int StoreID)
    {
        var Store = await _StoreService.Read(StoreID);

        if (Store is null)
        {
            return NotFound();
        }

        return Store;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Store newStore)
    {
        await _StoreService.Create(newStore);

        return CreatedAtAction(nameof(Get), new { id = newStore.StoreId }, newStore);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(int StoreId, Store updatedStore)
    {
        var Store = await _StoreService.Read(StoreId);

        if (Store is null)
        {
            return NotFound();
        }

        await _StoreService.Update(StoreId, Store);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(int StoreID)
    {
        var Store = await _StoreService.Read(StoreID);

        if (Store is null)
        {
            return NotFound();
        }

        await _StoreService.Delete(StoreID);

        return NoContent();
    }
}
