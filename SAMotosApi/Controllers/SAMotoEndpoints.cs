using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using SAMotosApi.Data;
using SAMotosMVC.Models;
namespace SAMotosApi.Controllers;

public static class SAMotoEndpoints
{
    public static void MapSAMotoEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/SAMoto").WithTags(nameof(SAMoto));

        group.MapGet("/", async (SAMotosApiContext db) =>
        {
            return await db.SAMoto.ToListAsync();
        })
        .WithName("GetAllSAMotos")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<SAMoto>, NotFound>> (int idsamoto, SAMotosApiContext db) =>
        {
            return await db.SAMoto.AsNoTracking()
                .FirstOrDefaultAsync(model => model.idSAMoto == idsamoto)
                is SAMoto model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSAMotoById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idsamoto, SAMoto sAMoto, SAMotosApiContext db) =>
        {
            var affected = await db.SAMoto
                .Where(model => model.idSAMoto == idsamoto)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.idSAMoto, sAMoto.idSAMoto)
                    .SetProperty(m => m.SAmodelo, sAMoto.SAmodelo)
                    .SetProperty(m => m.SAmarca, sAMoto.SAmarca)
                    .SetProperty(m => m.SAcilindraje, sAMoto.SAcilindraje)
                    .SetProperty(m => m.SAcolor, sAMoto.SAcolor)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSAMoto")
        .WithOpenApi();

        group.MapPost("/", async (SAMoto sAMoto, SAMotosApiContext db) =>
        {
            db.SAMoto.Add(sAMoto);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/SAMoto/{sAMoto.idSAMoto}",sAMoto);
        })
        .WithName("CreateSAMoto")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idsamoto, SAMotosApiContext db) =>
        {
            var affected = await db.SAMoto
                .Where(model => model.idSAMoto == idsamoto)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSAMoto")
        .WithOpenApi();
    }
}
