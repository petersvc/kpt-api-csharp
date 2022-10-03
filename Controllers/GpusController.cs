using Microsoft.AspNetCore.Mvc;
using KPT_back.Models;
using KPT_back.Services;

namespace KPT_back.Controllers;

[Controller]
[Route("[controller]")]
public class GpusController : ControllerBase
{
    private readonly MongoDBService _mongoDBService;

    public GpusController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Gpu>> Get()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Gpu gpu)
    {
        await _mongoDBService.CreateAsync(gpu);
        return CreatedAtAction(nameof(Get), new { id = gpu.Id }, gpu);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddGpu(string id, [FromBody] string gpuId)
    {
        await _mongoDBService.AddToGpuAsync(id, gpuId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }
}